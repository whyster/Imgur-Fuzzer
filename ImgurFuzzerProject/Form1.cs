using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;

namespace ImgurFuzzerProject {
    public partial class Form1 : Form {
        // Valid characters for imgur decorator
        public string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                                   "abcdefghijklmnopqrstuvwxyz" +
                                   "0123456789";
        // Webclient is space intensive, beneficial for it to be global
        public HttpClient webClient = new HttpClient();

        public Form1() {
            InitializeComponent();
            // To make requests to imgur, we need a user-agent flag for the request to not fail
            webClient.DefaultRequestHeaders.Add("User-Agent", "Imgur-Fuzzer: Tool");

            //Make save file dialog show up in installation path
            saveFileDialog.InitialDirectory = Application.StartupPath;
        }

        // Save file dialog event handler
        private void OpenSaveFileDialog(object sender, EventArgs e) {
            saveFileDialog.ShowDialog();
            saveFileLocation.Text = saveFileDialog.FileName;
        }

        // Start button event handler
        private void StartFuzzing(object sender, EventArgs e) {
            if (saveFileLocation.Text == "") {
                errorProvider1.SetError(saveFileLocation, "Save file location required");
            }
            else {
                //Backgroundworker as UI hangs if fuzzing is started synchronously
                backgroundWorker1.RunWorkerAsync();
            }
        }

        // Fuzzing method to be ran by backgroundworker1
        private void StartFuzzingBackground(object sender, DoWorkEventArgs e) {
            
            /* Imgur image links have a 7 character long alphanumeric identifier
             * E. G. https://i.imgur.com/ABC00F0/
             */
            string url = "https://i.imgur.com/";
            int[] decoratorPos = new int[7]; // Initializing a decorator position array
            
            
            for (int i = 0; i < 7; i++) {
                char character = logBox.Text[i];
                decoratorPos[i] = characters.IndexOf(character);
            }
            // Check if the saveFileLocation has been set
            if(saveFileLocation.Text != "") {
                startButton.Enabled = false; 
                stopButton.Enabled = true;

                /* Problem: To iterate through every possible imgur link, decorator must be iteratively stepped up
                 * Solution: Use the decoratorPos array to select characters from the predetermined characters string
                 * and add 1 to the [0] position. Once any [n] position in decoratorPos hits the length of characters
                 * reset [n] to 0 and add 1 to [n+1] 
                 */
                while (decoratorPos[6] < characters.Length) {
                    if (backgroundWorker1.CancellationPending) {
                        e.Cancel = true;
                        break;
                    }

                    string decorator = "";
                    decoratorPos[0] += 1;
                    // Iterate through all decoratorPositions and check if anypart hit the max
                    for (int i = 0; i < decoratorPos.Length-1; ++i) {
                        if (decoratorPos[i] >= characters.Length) {
                            decoratorPos[i] = 0;
                            decoratorPos[i + 1] += 1;
                        }
                    }

                    /*construct a decorator from the positions
                     * Python: ''.join([characters[num] for num in decoratorPos])
                     */
                    foreach (var num in decoratorPos) {
                        decorator += characters[num];
                    }

                    logBox.Text = $"{decorator}";
                    string result = CheckIfUrlValid($"{url}{decorator}.png");
                    // Check if result is not a redirect
                    if (result != "https://i.imgur.com/removed.png") {
                        /* Storing data in memory to write all in one go is not a stable course of action
                         * This writes the data immediately so no memory leak can take place
                         */
                        // File.AppendAllText(saveFileLocation.Text, $"\n\"{result}\",");
                        File.AppendAllText(saveFileLocation.Text, $"\n{result}");
                    }
                }

                
                startButton.Enabled = true;
                stopButton.Enabled = false;
            }
            else {
                errorProvider1.SetError(saveFileLocation, "Save file location required");
            }
            
            //CheckIfUrlValid("https://i.imgur.com/ka7Ln7w.png");
            
        }

        /* CheckIfUrlValid
         * Params: URL (A string representing a potential i.imgur image url)
         * Returns the URL passed in, if the url is a valid imgur image
         */
        private string CheckIfUrlValid(string url) {
            string imgDirect = "https://i.imgur.com/removed.png";
            //Query the url
            var res = webClient.GetAsync(url).Result;
            //Get an image from the stream
            Image image = Image.FromStream(res.Content.ReadAsStreamAsync().Result);
            if (image != null) {
                //If image exists, show it on the imgurPreview
                imgurPreview.Image = image;
            }
            return (res.RequestMessage.RequestUri.AbsoluteUri == imgDirect) ? imgDirect : res.RequestMessage.RequestUri.AbsoluteUri;
        }
        // Move the cursor to the end of the logBox, so newest errors are constantly shown
        private void TextScroll(object sender, EventArgs e) {
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        // Stop button event handler
        private void StopFuzzingWorker(object sender, EventArgs e) {
            stopButton.Enabled = false;
            backgroundWorker1.CancelAsync();
        }
    }
}