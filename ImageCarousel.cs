using System.ComponentModel;
using System.Net;

namespace _3951_Lab6_Bryson_Polina
{
    /// <summary>
    /// USer control that displays an image list as a carousel.
    /// Loads some default images and provides a file dialog to add images from 
    /// the local file system.
    /// </summary>
    public partial class ImageCarousel : UserControl
    {
        private List<Image> _imageList = new List<Image>();
        private int _curIndex          = -1;
        private bool _loadedDefaults   = false;

        public event EventHandler ImageChanged;

        public ImageCarousel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Overrides the default onload to add default images to the image list.
        /// Uses the loadedDefaults boolean to make sure default are only loaded once.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if(!DesignMode && !_loadedDefaults)
            {
                LoadDefaults();
                _loadedDefaults = true;
            }
        }

        /// <summary>
        /// A list to store the images in the image carousel
        /// </summary>
        [Category("Custom Carousel")]
        [Description("The images to display in the carousel.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Image> ImageList
        {
            get => _imageList;
            set
            {
                _imageList = value ?? new List<Image>();
                if (_imageList.Count > 0)
                {
                    CurIndex = 0;
                }
                else
                {
                    CurIndex = -1;
                }
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Index of the current image being displayed.
        /// Gets updated automatically by the OnImageChanged event.
        /// </summary>
        [Category("Custom Carousel")]
        [Description("The index of the currently displayed image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurIndex
        {
            get => _curIndex;
            set
            {
                if (value < 0 || value >= _imageList.Count)
                {
                    return; // do nothing if index out of range
                }

                if (_curIndex != value)
                {
                    _curIndex = value;
                    UpdateDisplay();
                    OnImageChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Raises the image changed event when the image changes.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnImageChanged(EventArgs e)
        {
            ImageChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Refreshes the main picture box to show the image corresponding to
        /// the current index.
        /// </summary>
        private void UpdateDisplay()
        {
            if (_imageList.Count == 0)
            {
                pictureBoxMain.Image = null;
            }
            else
            {
                pictureBoxMain.Image = _imageList[_curIndex];
            }
        }

        /// <summary>
        /// Decremenets the index by 1 and wraps around to the last image if the current
        /// index is the first image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (_imageList.Count == 0)
            {
                return;
            }

            int newIndex = _curIndex - 1;
            if (newIndex < 0)
            {
                newIndex = _imageList.Count - 1; // wrap around if at first image
            }

            CurIndex = newIndex;
        }

        /// <summary>
        /// Increments the index by 1 and wraps around to the first image if the current
        /// index is the last image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_imageList.Count == 0)
            {
                return;
            }

            int newIndex = _curIndex + 1;
            if (newIndex >= _imageList.Count)
            {
                newIndex = 0;
            }

            CurIndex = newIndex;
        }

        /// <summary>
        /// Uses an open file dialog to let the user add images from the local file system,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddImages_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in ofd.FileNames)
                    {
                        try
                        {
                            Image img = Image.FromFile(fileName);
                            _imageList.Add(img);
                        }
                        catch (FileNotFoundException fnf)
                        {
                            MessageBox.Show($"Couldn't find {fileName}:\n{fnf.Message}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error loading {fileName}:\n{ex.Message}");
                        }
                    }

                    if (_imageList.Count > 0 && _curIndex < 0)
                    {
                        CurIndex = 0;
                    }
                    else
                    {
                        CurIndex = _imageList.Count - 1;
                    }

                    UpdateDisplay();
                }
            }
        }

        /// <summary>
        /// Uses httpClient to grab some random images from picsum.photos so the carousel
        /// is loaded with default images.
        /// </summary>
        private void LoadDefaults()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    string url = "https://picsum.photos/200/300?random=" + Guid.NewGuid();
                    using (HttpClient hc = new())
                    {
                        byte[] imageData = hc.GetByteArrayAsync(url).Result;
                        using (MemoryStream ms = new(imageData))
                        {
                            Image img = Image.FromStream(ms);
                            _imageList.Add(img);
                        }
                    }
                }

                if (_imageList.Count > 0 && _curIndex < 0)
                {
                    _curIndex = 0;
                }

                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading default images: " + ex.Message);
            }
        }
    }
}
