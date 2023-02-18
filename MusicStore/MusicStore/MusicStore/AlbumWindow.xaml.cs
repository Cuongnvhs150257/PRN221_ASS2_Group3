using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for AlbumWindow.xaml
    /// </summary>
    public partial class AlbumWindow : Window
    {

        MusicStoreContext context = new MusicStoreContext();

        public AlbumWindow()
        {
            InitializeComponent();
            lvAlbum.ItemsSource = context.Albums.ToList();
            cbGenre.ItemsSource = context.Genres.ToList().Select(name => name.Name).ToList();
            cbArtist.ItemsSource = context.Artists.ToList().Select(name => name.Name).ToList();
        }

        private void cbGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var album = lvAlbum.SelectedItem as Album;
            if (album != null)
            {
                MessageBoxResult messageResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageResult == MessageBoxResult.No)
                {
                    return;
                }
                try
                {
                    context.Albums.Remove(album);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show($"{album.Title} Delete success");
                        LoadAlbum();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadAlbum()
        {
            lvAlbum.ItemsSource = context.Albums.ToList();
            cbGenre.ItemsSource = context.Genres.ToList().Select(name => name.Name).ToList();
            cbArtist.ItemsSource = context.Artists.ToList().Select(name => name.Name).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Genre genre = context.Genres.SingleOrDefault(ge => ge.Name == cbGenre.Text);
                Artist artist = context.Artists.SingleOrDefault(co => co.Name == cbArtist.Text);
                Album album = new Album
                {

                    GenreId = genre.GenreId,
                    Title = txtTitle.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    AlbumUrl = txtUrl.Text,
                    ArtistId = artist.ArtistId

                };
                context.Albums.Add(album);
                int count = context.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Insert success");
                    LoadAlbum();
                }
                else
                {
                    MessageBox.Show("Insert failure");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Genre genre = context.Genres.SingleOrDefault(ge => ge.Name == cbGenre.Text);
                Artist artist = context.Artists.SingleOrDefault(co => co.Name == cbArtist.Text);
                var album = lvAlbum.SelectedItem as Album;
                if (album != null)
                {
                    album.Title = txtTitle.Text;
                    album.GenreId = genre.GenreId;
                    album.ArtistId = artist.ArtistId;
                    album.Price = decimal.Parse(txtPrice.Text);
                    album.AlbumUrl = txtUrl.Text;
                    context.Albums.Update(album);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show($"{album.Title} Update success");
                        LoadAlbum();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Insert error: " + ex.Message);
            }
        }
    }
    
}
