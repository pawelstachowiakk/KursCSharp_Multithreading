using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            // ONE
            Task<int> getLengthTask = AccessTheWebAsync();

            // FOUR
            int contentLength = await getLengthTask;

            // SIX
            resultsTextBox.Text +=
                $"\r\nLength of the downloaded string: {contentLength}.\r\n";
        }

        async Task<int> AccessTheWebAsync()
        {
            // TWO
            HttpClient client = new HttpClient();
            Task<string> getStringTask =
                client.GetStringAsync("https://msdn.microsoft.com");

            // THREE
            string urlContents = await getStringTask;

            // FIVE
            return urlContents.Length;
        }
    }
}
