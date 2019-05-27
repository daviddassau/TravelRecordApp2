using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostDetailPage : ContentPage
	{
        // Global property of type post
        Post selectedPost;

		public PostDetailPage(Post selectedPost)
		{
			InitializeComponent();

            this.selectedPost = selectedPost;

            experienceEntry.Text = selectedPost.Experience;
		}

        void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully updated", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be updated", "Ok");
            }
        }

        void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully deleted", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
            }
        }
    }
}