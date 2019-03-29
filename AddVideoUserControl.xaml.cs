using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Net;

namespace SilverStreamingVideoForm
{
	public partial class AddVideoUserControl : UserControl
	{
        private OpenFileDialog ofd = new OpenFileDialog();
        private bool fileSelected;
        private int remaining, data, offset, read;

		public AddVideoUserControl()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        private void loadVideoButton_Click(object sender, RoutedEventArgs e)
        {   
            ofd.Filter = "All Files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog().HasValue)
            {
                saveAsInput.Text = ofd.File.Name;
                fileSelected = true;
            }
            else
            {
                // Do Nothing !
            }
        }

        private void uploadVideoText_Click(object sender, RoutedEventArgs e)
        {
            if (fileSelected)
            {
                byte[] data = new byte[ofd.File.Length];

                Stream stream = ofd.File.OpenRead();

                //remaining = data.GetLength(0);
                //offset = 0;

                //while (remaining > 0)
                //{
                //    read = stream.Read(data, offset, remaining);
                //    if (read <= 0)
                //        throw new EndOfStreamException
                //            (String.Format("End of stream reached with {0} bytes left to read", remaining));
                //    remaining -= read;
                //    offset += read;
                //}

                ServiceReference1.Service1Client srv = new SilverStreamingVideoForm.ServiceReference1.Service1Client();

                srv.SaveFileCompleted += (sender1, e1) =>
                {
                    MessageBox.Show("Operation Completed.");
                    saveAsInput.Text = "";
                    fileSelected = false;

                    //stream.Dispose();
                };

                //srv.SaveFileAsync(saveAsInput.Text, data);

                
            }
        }
	}
}