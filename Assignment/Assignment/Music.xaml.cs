using Assignment.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment.Assignment
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Music : Page
    {
        private string ApiUpload = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/post-free";

        public Music()
        {
            this.InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ValidateName.Text = "";
            this.ValidateLink.Text = "";
            this.ValidateThumbnail.Text = "";

            if (this.Name.Text.Length == 0)
            {
                this.ValidateName.Text = "It nhat 1 ki tu";
                return;
            }
            if (this.Name.Text.Length > 50)
            {
                this.ValidateName.Text = "Toi da 50 ki tu";
                return;
            }

            if (this.Thumbnail.Text == "")
            {
                this.ValidateThumbnail.Text = "Khong duoc de trong";
                return;
            }

            if (this.Link.Text == "")
            {
                this.ValidateLink.Text = "khong duoc de trong";
                return;
            }
            if (!this.Link.Text.EndsWith(".mp3"))
            {
                this.ValidateLink.Text = "duoi phai la mp3";
                return;
            }

            Song song = new Song()
            {
                name = this.Name.Text,
                description = this.Description.Text,
                singer = this.Singer.Text,
                author = this.Author.Text,
                thumbnail = this.Thumbnail.Text,
                link = this.Link.Text,
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            var response = httpClient.PostAsync(ApiUpload, content).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(response);




        }
    }
}
