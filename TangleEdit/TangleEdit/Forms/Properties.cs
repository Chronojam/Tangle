using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangleEngine.Entities;
using Microsoft.Xna.Framework;
using TangleEngine.Entities.Entity_Behaviours;
using TangleEngine.Entities.Entity_Properties;

namespace TangleEdit
{
    public partial class Properties : Form
    {
        public Properties()
        {
            InitializeComponent();
        }

        private void Properties_Load(object sender, EventArgs e)
        {
            
        }

        public void GetEntityData(Entity Ent)
        {
            if (Ent == null)
            {
                listView1.Items.Clear();
            }
            else
            {
                ClearProperties();
                this.Text = "Properties of " + Ent.Name;

                listView1.Items.Add(Ent.Name);
                listView1.Items[0].SubItems.Add("Name");

                foreach (Behaviour b in Ent.behaviours)
                {
                    listView1.Items.Add("True").SubItems.Add(b.GetType().Name);
                }
                foreach (KeyValuePair<Type, Dictionary<string, object>> prop in Ent.propertiesD)
                {
                    foreach (KeyValuePair<string, object> dic in prop.Value)
                    {
                        listView1.Items.Add(dic.Value.GetType().GetProperty("Value").GetValue(dic.Value, null).ToString()).SubItems.Add(dic.Key);
                    }
                }
            }
        }

        private void ClearProperties()
        {
            this.Text = "Properties";
            listView1.Items.Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
