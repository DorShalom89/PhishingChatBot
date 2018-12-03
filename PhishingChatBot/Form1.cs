using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhishingChatBot
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.AcceptButton = btnCheck;
            this.ActiveControl = urlTextBox;
            InitializeComponent();
        }

        private void Check()
        {
            string input = urlTextBox.Text;

            chatUpdate("User:" + input);

            if (PhishChecker.ValidateUrl(input))
            {
                if (PhishChecker.CheckUrl(input)) chatUpdate("Warning: Phishing alert, this url is in the phishing database");
                else chatUpdate("This url is safe");
            }
            else chatUpdate("Please enter a valid url (Including http or https)");       }

        //Update the chat box safely without cross-thread.
        private void chatUpdate(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { chatBox.Items.Add(text); }));
            }
            else chatBox.Items.Add(text);   
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //Using task so UI wont hang while working.
            Task.Run(() => Check());
        }
    }
}
