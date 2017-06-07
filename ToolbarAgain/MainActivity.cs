using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using ToolbarAgain.Adapter;
using ToolbarAgain.Model;
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
            toolbar.Title = "Home Page";

            toolbar.InflateMenu(Resource.Menu.ToolbarMenu);


            SetupRecyclerView();

            //toolbar.MenuItemClick += (sender, e) =>
            //{
            //    var msg = "";
            //    switch (e.Item.ItemId)
            //    {
            //        case Resource.Id.discard:
            //            msg = "Discard";
            //            break;
            //        case Resource.Id.search:
            //            msg = "Search";
            //            break;
            //        case Resource.Id.edit:
            //            msg = "Edit";
            //            break;
            //        case Resource.Id.settings:
            //            msg = "Setting";
            //            break;
            //        case Resource.Id.exit:
            //            msg = "Exit";
            //            break;
            //    }

            //    Toast.MakeText(this, msg, ToastLength.Short).Show();
            //};
        }

        private void SetupRecyclerView()
        {
            RecyclerView recyclerView = (RecyclerView) FindViewById(Resource.Id.recyclerView);
            RecyclerAdapter adapter = new RecyclerAdapter(this, Landscape.GetData());

            recyclerView.SetAdapter(adapter);

            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            recyclerView.SetLayoutManager(linearLayoutManager);

            recyclerView.SetItemAnimator(new DefaultItemAnimator());

        }
    }
}

