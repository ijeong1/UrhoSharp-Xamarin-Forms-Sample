using Urho;
using Urho.Forms;
using Xamarin.Forms;

namespace UrhoSharpSample
{
    public partial class MainPage : ContentPage
    {
        UrhoSurface urhoSurface;
        Charts urhoApp;
        Slider heightSlider;
        Slider widthSlider;
        Slider depthSlider;

        public MainPage()
        {
            InitializeComponent();

            urhoSurface = new UrhoSurface();
            urhoSurface.VerticalOptions = LayoutOptions.FillAndExpand;

            heightSlider = new Slider(0, 5, 2.5);
            heightSlider.ValueChanged += OnHeightValuesSliderValueChanged;

            widthSlider = new Slider(0, 5, 2.5);
            widthSlider.ValueChanged += OnWidthValuesSliderValueChanged;

            depthSlider = new Slider(0, 5, 2.5);
            depthSlider.ValueChanged += OnDepthValuesSliderValueChanged;

            Title = " UrhoSharp + Xamarin.Forms";
            Content = new StackLayout
            {
                Padding = new Thickness(12, 12, 12, 40),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    urhoSurface,
                    new Label { Text = "Height (in):" },
                    heightSlider,
                    new Label { Text = "Width (in):" },
                    widthSlider,
                    new Label { Text = "Depth (in):" },
                    depthSlider
                }
            };
        }

        protected override void OnDisappearing()
        {
            UrhoSurface.OnDestroy();
            base.OnDisappearing();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //await HelloWorldUrhoSurface.Show<Charts>(new ApplicationOptions(assetsFolder: null) { Orientation = ApplicationOptions.OrientationType.LandscapeAndPortrait });
            urhoApp = await urhoSurface.Show<Charts>(new ApplicationOptions(assetsFolder: null) { Orientation = ApplicationOptions.OrientationType.LandscapeAndPortrait });

        }

        void OnHeightValuesSliderValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            urhoApp.SelectedBar.HeightValue = (float)e.NewValue;
        }

        void OnWidthValuesSliderValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            urhoApp.SelectedBar.WidthValue = (float)e.NewValue;
        }

        void OnDepthValuesSliderValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            urhoApp.SelectedBar.DepthValue = (float)e.NewValue;
        }

    }
}
