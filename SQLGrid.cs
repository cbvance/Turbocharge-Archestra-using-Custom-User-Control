using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLGridControl
{
    public delegate void BatchIDChangedEventHandler(object sender, SQLGridEventArgs e);

    

    public partial class SQLGrid : UserControl
    {
        


        public SQLGrid()
        {
            InitializeComponent();

        }

        DataTable _DataSource = new DataTable();
        Int16 _BatchID = 1;

        //DataSource provides data table for data view grid 
        [Browsable(true)]
        [Description("Data View Grid for SQL"), Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public DataTable DataSource
        {
            get { return _DataSource; }
            set
            {
                _DataSource = value;


                try
                {                   
                    dataGridView1.DataSource = _DataSource;
                }
                catch { }
            }
        }

        //DataSource provides data table for data view grid 
        [Browsable(true)]
        [Description("Batch ID"), Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public Int16 BatchID
        {
            get { return _BatchID; }
            set
            {
                //data for event args
                //Int16 BatchID = new Int16();
                //build event args
                SQLGridEventArgs args = new SQLGridEventArgs(BatchID);
                //Raise the event
                OnBatchIDChangedEvent(args);
                _BatchID = value;

            }
        }

        //Declare the event using the delegate handler. Set a Browsable so it shows in the designer
        [Browsable(true)]
        public event BatchIDChangedEventHandler BatchIDChangedEvent;
        //Method that raises the event
        protected virtual void OnBatchIDChangedEvent(SQLGridEventArgs e)
        {
            //Ensure the event is not null 
            BatchIDChangedEventHandler bidceh = this.BatchIDChangedEvent;
            if (bidceh != null)
                bidceh(this, e);
        }

        //Finally, the method which raises the event
        public void DoStuffToRaiseEvent()
        {
            //data for event args
            Int16 BatchID = new Int16();
            //build event args
            SQLGridEventArgs args = new SQLGridEventArgs(BatchID);
            //Raise the event
            OnBatchIDChangedEvent(args);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _BatchID++;

            //data for event args
            //Int16 BatchID = new Int16();
            //build event args
            SQLGridEventArgs args = new SQLGridEventArgs(BatchID);
            //Raise the event
            OnBatchIDChangedEvent(args);
        }
    }

    public class SQLGridEventArgs : EventArgs
    {
        private Int16 BatchID;

        public SQLGridEventArgs(Int16 _BatchID)
        {
            this.BatchID = _BatchID;
        }

        public Int16 _BatchID
        {
            get { return this.BatchID; }
        }
    }
}
