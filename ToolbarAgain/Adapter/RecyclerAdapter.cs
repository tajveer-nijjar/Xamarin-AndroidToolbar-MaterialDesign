using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ToolbarAgain.Model;

namespace ToolbarAgain.Adapter
{
    public class RecyclerAdapter: RecyclerView.Adapter
    {
        private readonly Activity _activity;
        private List<Landscape> _images;


        public RecyclerAdapter(Activity activity, List<Landscape> data)
        {
            _activity = activity;

            this._images = data;
        }

        // Creates new view (invoked by layout manager)
        // This ll run for as many number of times as there are images on the screen at one time.
        //    eg, there are 7 records shown on the display at one time. So this ll run only 7 times
        //    to create the view for the first 7 records only. After that it ll not run.
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Setup and inflate your layout here.
            var id = Resource.Layout.list_item;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new MyViewHolder(itemView);

        }



        // Replace the contents of a view (invoked by layout manager)
        // Runs for each image.
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {


            Landscape currentItem = _images[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as MyViewHolder;
            holder.SetData(currentItem, position);

            //holder.Title.Text = item.Title;
            //holder.Image
        }



        public override int ItemCount => _images.Count;  
    }




    public class MyViewHolder : RecyclerView.ViewHolder
    {
        private TextView _title;
        private ImageView _imgThumb, _imgDelete, _imgAdd;
        private int _position;
        private Landscape _currentItem;

        public MyViewHolder(View itemView) : base(itemView)
        {
            _imgThumb = (ImageView)itemView.FindViewById(Resource.Id.img_row);
            _title = (TextView) itemView.FindViewById(Resource.Id.tvTitle);
            _imgAdd = (ImageView)itemView.FindViewById(Resource.Id.img_row_add);
            _imgDelete = (ImageView)itemView.FindViewById(Resource.Id.img_row_delete);



        }

        public void SetData(Landscape currentItem, int position)
        {
            _title.Text = currentItem.Title;
            _imgThumb.SetImageResource(currentItem.ImageId);
            this._position = position;
            _currentItem = currentItem;
        }
    }
}