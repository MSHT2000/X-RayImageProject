using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Xray_image_new_Project
{
    public partial class FilterForm : Form
    {
        ImageList myImageList = new ImageList();
        public FilterForm()
        {
            InitializeComponent();
            
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            if (Size_radio_Button.Checked == true)
            {
                if (SizeTextBox.Text!="")
                {

                AddImagesToListViewWithSizeFilter("C:\\Users\\ABC\\Desktop\\Xray_image", listView1,myImageList, long.Parse(SizeTextBox.Text));
                }
                else
                {
                    MessageBox.Show("Size field is required!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
            }
            else if (Date_radio_Button.Checked== true)
            {

            AddImagesToListViewWithDateFilter("C:\\Users\\ABC\\Desktop\\Xray_image", listView1, myImageList, dateTimePicker1.Value.Date);
                
            }
        }

        public void AddImagesToListViewWithSizeFilter(string directoryPath, ListView listView, ImageList imageList, long sizeInKb)
        {
            // Ensure the ListView and ImageList are cleared each time the method is called
            listView.Items.Clear();
            imageList.Images.Clear();

            // Set the ImageList properties
            imageList.ImageSize = new Size(100, 100); // Thumbnail size
            listView.LargeImageList = imageList;

            // Check if the directory exists
          if (Directory.Exists(directoryPath))
          {
                // Get all files with image extensions (jpg, png, gif, bmp)
                var imageFiles = Directory.GetFiles(directoryPath, "*.*")
                    .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png")
                        || file.EndsWith(".gif") || file.EndsWith(".bmp"));
                if (imageFiles.Any())
                {



                    // Iterate over each file, check the size, and add it to the ListView
                    foreach (var file in imageFiles)
                    {
                        try
                        {
                            // Get the file info
                            FileInfo fileInfo = new FileInfo(file);

                            // Convert the size to KB and compare with the user-specified size
                            long fileSizeInKb = fileInfo.Length / 1024;
                            if (fileSizeInKb == sizeInKb)
                            {
                                // Load the image from the file
                                using (Image image = Image.FromFile(file))
                                {
                                    // Create a thumbnail of the image
                                    Image thumbnail = image.GetThumbnailImage(imageList.ImageSize.Width,
                                                                              imageList.ImageSize.Height,
                                                                              () => false, IntPtr.Zero);

                                    // Add the thumbnail to the ImageList
                                    imageList.Images.Add(thumbnail);

                                    // Create a new ListViewItem
                                    ListViewItem item = new ListViewItem(Path.GetFileName(file));

                                    // Set the image index to the last image added to the ImageList
                                    item.ImageIndex = imageList.Images.Count - 1;

                                    // Optionally set the Tag property to the full file path for later use
                                    item.Tag = file;

                                    // Add the ListViewItem to the ListView
                                    listView.Items.Add(item);
                                }
                            }

                        }
                        catch (OutOfMemoryException)
                        {
                            MessageBox.Show("An image file is not valid or supported.");
                        }
                    }


                    if (listView1.Items.Count == 0 && imageFiles.Any() == true)
                    {
                        MessageBox.Show("There are no images of this size:" + sizeInKb + " KB", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            
            else
            {
                MessageBox.Show("There are no images in this path", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
          else
          {
                MessageBox.Show("Directory does not exist.");
          }
        }

        public void AddImagesToListViewWithDateFilter(string directoryPath, ListView listView, ImageList imageList, DateTime userSpecifiedDate)
        {
            // Ensure the ListView and ImageList are cleared each time the method is called
            listView.Items.Clear();
            imageList.Images.Clear();

            // Set the ImageList properties
            imageList.ImageSize = new Size(100, 100); // Thumbnail size
            listView.LargeImageList = imageList;

            // Check if the directory exists
            if (Directory.Exists(directoryPath))
            {
                // Get all files with image extensions (jpg, png, gif, bmp)
                var imageFiles = Directory.GetFiles(directoryPath, "*.*")
                    .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png")
                        || file.EndsWith(".gif") || file.EndsWith(".bmp"));

                // Iterate over each file, check the modified date, and add it to the ListView
                if (imageFiles.Any())
                { 
                  foreach (var file in imageFiles)
                {
                    try
                    {
                        // Get the file info
                        FileInfo fileInfo = new FileInfo(file);

                        // Check if the last modified date matches the user-specified date
                        if (fileInfo.LastWriteTime.Date == userSpecifiedDate.Date)
                        {
                            // Load the image from the file
                            using (Image image = Image.FromFile(file))
                            {
                                // Create a thumbnail of the image
                                Image thumbnail = image.GetThumbnailImage(imageList.ImageSize.Width,
                                                                          imageList.ImageSize.Height,
                                                                          () => false, IntPtr.Zero);

                                // Add the thumbnail to the ImageList
                                imageList.Images.Add(thumbnail);

                                // Create a new ListViewItem
                                ListViewItem item = new ListViewItem(Path.GetFileName(file));

                                // Set the image index to the last image added to the ImageList
                                item.ImageIndex = imageList.Images.Count - 1;

                                // Optionally set the Tag property to the full file path for later use
                                item.Tag = file;

                                // Add the ListViewItem to the ListView
                                listView.Items.Add(item);
                            }
                        }
                    }
                    catch (OutOfMemoryException)
                    {
                        MessageBox.Show("An image file is not valid or supported.");
                    }
                }
                   if (listView1.Items.Count == 0 && imageFiles.Any() == true)
                    {
                        MessageBox.Show("There are no images modified in :" + dateTimePicker1.Value.Date, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("There are no images in this path", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                  
            }
            else
            {
                MessageBox.Show("Directory does not exist.");
            }


        }

        private void Date_radio_Button_CheckedChanged(object sender, EventArgs e)
        {
            if(Date_radio_Button.Checked== true) {
                dateTimePicker1.Visible = true;
                SizeTextBox.Visible = false;
                SizeLabel.Visible = false;
            }
        }

        private void Size_radio_Button_CheckedChanged(object sender, EventArgs e)
        {
            if(Size_radio_Button.Checked== true)
            {
                dateTimePicker1.Visible = false;
                SizeTextBox.Visible = true;
                SizeLabel.Visible = true;
            }
        }
    }

       
    }

