using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks ;
using System.Net;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Security.Policy;

namespace clas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Root responseObj = default;
        private void button1_Click_1(object sender, EventArgs e)
        {

            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjZjN2U5MTZlLTNlMDQtNDg0OC1hMzljLTRlN2RiYjkyYTIwMiIsImlhdCI6MTY3OTA5MTIzMSwic3ViIjoiZGV2ZWxvcGVyL2VmZjRlMGZjLTZmZmUtZDJiYi1hZDZiLTc3N2M4MTI4MzE0MCIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjg3LjQuMTQ2LjE0NSJdLCJ0eXBlIjoiY2xpZW50In1dfQ.N4o8mdCdjTbOno0oaH6gmUdMDcwpAxGDktOjjp9cfTWCfJR7gIa1vSOIh4EelrOCFE__OpwUnAFqncQfMj9-Xg";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string id = textBox1.Text;



            var response = httpClient.GetAsync($"https://api.clashofclans.com/v1/players/%23{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonStringResponse = response.Content.ReadAsStringAsync().Result;
                responseObj = JsonConvert.DeserializeObject<Root>(jsonStringResponse);


            }

            string url = responseObj.League.IconUrls.Medium.ToString();
            byte[] image = (new WebClient()).DownloadData(url);
            Image a = ((Func<Image>)(() =>
            {
                using (var ms = new MemoryStream(image))
                {
                    return Image.FromStream(ms);
                }
            }))();

            pictureBox1.Image = a;

            label2.Text = responseObj.Trophies.ToString();

            label3.Text = responseObj.Name.ToString();
        }
        private void button2_Click(object sender, EventArgs e)// C2LGJGPQ
        {

            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjZjN2U5MTZlLTNlMDQtNDg0OC1hMzljLTRlN2RiYjkyYTIwMiIsImlhdCI6MTY3OTA5MTIzMSwic3ViIjoiZGV2ZWxvcGVyL2VmZjRlMGZjLTZmZmUtZDJiYi1hZDZiLTc3N2M4MTI4MzE0MCIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjg3LjQuMTQ2LjE0NSJdLCJ0eXBlIjoiY2xpZW50In1dfQ.N4o8mdCdjTbOno0oaH6gmUdMDcwpAxGDktOjjp9cfTWCfJR7gIa1vSOIh4EelrOCFE__OpwUnAFqncQfMj9-Xg";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string locations = textBox2.Text;

            var ob = new JObject();
            int id = 0;
            // Richiedi list locations
            // Cerca tra location quella inserita
            // Prendi l'id
            // Dopo inserisce quell id

            Debug.Write($"https://api.clashofclans.com/v1/locations/{locations}");
            var response = httpClient.GetAsync($"https://api.clashofclans.com/v1/locations/").Result;
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
                var jsonStringResponse = response.Content.ReadAsStringAsync().Result;
                ob = JObject.Parse(jsonStringResponse);
                for (int i = 0; i < (ob["items"]).ToList().Count; i++)
                {
                    if (ob["items"][i]["name"].ToString().Equals(locations))
                    {

                        Debug.WriteLine("++++++++++++" + ob["items"][i]["name"].ToString() + "------:" + i);
                        id = Convert.ToInt32(ob["items"][i]["id"].ToString());
                        Debug.WriteLine("*************************" + id);
                    }
                }
                
                responseObj = JsonConvert.DeserializeObject<Root>(jsonStringResponse);


            }

            Debug.WriteLine("///////////////" + "https://api.clashofclans.com/v1/locations/" + id + "/rankings/players");

            response = httpClient.GetAsync($"https://api.clashofclans.com/v1/locations/" + id + "/rankings/players").Result;
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
                var jsonStringResponse = response.Content.ReadAsStringAsync().Result;
                ob = JObject.Parse(jsonStringResponse);
                Debug.WriteLine(ob);
                //Debug.WriteLine("+++++++++++++++++++++" + jsonStringResponse["items"][0]["name"]);
                responseObj = JsonConvert.DeserializeObject<Root>(jsonStringResponse);


            }

            label5.Text = ob["items"][0]["trophies"]?.ToString();

            label6.Text = ob["items"][0]["name"]?.ToString();

            label7.Text = ob["items"][0]["tag"]?.ToString();

            label8.Text = ob["items"][0]["attackWins"]?.ToString();

            label9.Text = ob["items"][0]["defenseWins"]?.ToString();

            label16.Text = ob["items"][0]["clan"]["name"]?.ToString();

            label17.Text = ob["items"][0]["clan"]["tag"]?.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjZjN2U5MTZlLTNlMDQtNDg0OC1hMzljLTRlN2RiYjkyYTIwMiIsImlhdCI6MTY3OTA5MTIzMSwic3ViIjoiZGV2ZWxvcGVyL2VmZjRlMGZjLTZmZmUtZDJiYi1hZDZiLTc3N2M4MTI4MzE0MCIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjg3LjQuMTQ2LjE0NSJdLCJ0eXBlIjoiY2xpZW50In1dfQ.N4o8mdCdjTbOno0oaH6gmUdMDcwpAxGDktOjjp9cfTWCfJR7gIa1vSOIh4EelrOCFE__OpwUnAFqncQfMj9-Xg";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string nc = textBox3.Text;
            var ob = new JObject();
            int id = 0;
            var response = httpClient.GetAsync($"https://api.clashofclans.com/v1/clans?name=" + nc).Result;

            PhotoClan photoResponse = new PhotoClan();

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
                var jsonStringResponse = response.Content.ReadAsStringAsync().Result;
                ob = JObject.Parse(jsonStringResponse);
                for (int i = 0; i < (ob["items"]).ToList().Count; i++)
                {
                    if (ob["items"][i]["name"].ToString().Equals(nc))
                    {

                        Debug.WriteLine("++++++++++++" + ob["items"][i]["name"].ToString() + "------:" + i);

                        photoResponse = JsonConvert.DeserializeObject<PhotoClan>(jsonStringResponse);
                        id = i;
                        Debug.WriteLine("*************************" + id);
                    }

                }

                string url = (photoResponse.items[id].badgeUrls.Medium);
                byte[] image = (new WebClient()).DownloadData(url);
                Image a = ((Func<Image>)(() =>
                {
                    using (var ms = new MemoryStream(image))
                    {
                        return Image.FromStream(ms);
                    }
                }))();

                pictureBox2.Image = a;

                label20.Text = ob["items"][id]["location"]["name"]?.ToString();
                label21.Text = ob["items"][id]["tag"]?.ToString();
                label24.Text = ob["items"][id]["type"]?.ToString();
                label26.Text = ob["items"][id]["clanLevel"]?.ToString();
                label28.Text = ob["items"][id]["clanPoints"]?.ToString();

            }
        }

      
    }
}
