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
            // 1
            Task<int> getLengthTask = AccessTheWebAsync();

            // 4
            int contentLength = await getLengthTask;

            // 6
            resultsTextBox.Text +=
                $"\r\nLength of the downloaded string: {contentLength}.\r\n";
        }

        async Task<int> AccessTheWebAsync()
        {
            // 2
            HttpClient client = new HttpClient();
            Task<string> getStringTask =
                client.GetStringAsync("https://msdn.microsoft.com");

            // 3
            string urlContents = await getStringTask;

            // 5
            return urlContents.Length;
        }
    }
}
