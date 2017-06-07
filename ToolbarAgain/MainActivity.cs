using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace ToolbarAgain
{
    [Activity(Label = "ToolbarAgain", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private Toolbar toolbar;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);



            toolbar = (Toolbar) FindViewById(Resource.Id.toolbar);
            toolbar.Title = "Welcome";

            toolbar.InflateMenu(Resource.Menu.ToolbarMenu);


            toolbar.MenuItemClick += (sender, e) =>
            {
                var msg = "";
                switch (e.Item.ItemId)
                {
                    case Resource.Id.discard:
                        msg = "Discard";
                        break;
                    case Resource.Id.search:
                        msg = "Search";
                        break;
                    case Resource.Id.edit:
                        msg = "Edit";
                        break;
                    case Resource.Id.settings:
                        msg = "Setting";
                        break;
                    case Resource.Id.exit:
                        msg = "Exit";
                        break;
                }

                Toast.MakeText(this, msg, ToastLength.Short).Show();
            };
        }
    }
}

