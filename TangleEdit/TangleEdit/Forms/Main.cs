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
using Microsoft.Xna.Framework.Graphics;
using TangleEngine.Entities.Entity_Behaviours.Brush_Behaviours;
using Microsoft.Xna.Framework.Content;
namespace TangleEdit
{
    public enum TabState
    {
        GeometeryTab,
        EntityTab,
        LightingTab,
    }
    public enum Geometrytype
    {
        Rectangle,
        Sphere,
    }

    public partial class Main : Form
    {
        #region Fields
        public Properties PropertiesForm = new Properties();
        List<TextBox> numericControls;

        #endregion

        #region Properties

        public TabState TabState
        {
            get { return tabState; }
            protected set { tabState = value; }
        }
        TabState tabState = TabState.GeometeryTab;

        public Geometrytype GeoType
        {
            get { return geoType; }
            protected set { geoType = value; }
        }
        Geometrytype geoType = Geometrytype.Rectangle;

        #endregion

        public Main()
        {
            InitializeComponent();
            PropertiesForm.Show();

            gameControl1.Click += new EventHandler(OnSelected);
            tabControl1.Click += new EventHandler(OnTabControlClicked);
            comboBox1.SelectedValueChanged += new EventHandler(OnGeometryTypeChanged);
        }

        #region Public Methods

        #endregion

        #region Helper Methods
        private void Mainform_Load(object sender, EventArgs e)
        {
            numericControls = new List<TextBox>
            {
                geoRotBoxX,
                geoRotBoxY,
                geoRotBoxZ,
                scaleXBox,
                scaleYBox,
                scaleZBox
            };
        }
        private void OnSelected(object sender, EventArgs e)
        {
            PropertiesForm.GetEntityData(gameControl1.GetSelectedEntityData());
            GetNewEntity();
        }
        // Event handler for switching the enum of the tabcontrol to whatever has been clicked
        private void OnTabControlClicked(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == geoMetry_Tab)
                tabState = TabState.GeometeryTab;
            if (tabControl1.SelectedTab == ent_Tab)
                tabState = TabState.EntityTab;
            if (tabControl1.SelectedTab == light_Tab)
                tabState = TabState.LightingTab;
        }
        // Event handler for switching the enum of the combobox to whatever has been clicked
        private void OnGeometryTypeChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == comboBox1.Items[0])
                geoType = Geometrytype.Rectangle;
            if (comboBox1.SelectedItem == comboBox1.Items[1])
                geoType = Geometrytype.Sphere;
        }
        // Event handler for the Geometry tab entity placement
        bool enableGeoPlacement = false;
        private void button1_Click(object sender, EventArgs e)
        {
            ent_Place.BackColor = DefaultBackColor;
            if (enableGeoPlacement == false)
            {
                ent_Place.Text = "Placing Ents Now";
                enableGeoPlacement = true;
            }
            else if (enableGeoPlacement == true)
            {
                ent_Place.Text = "Place";
                enableGeoPlacement = false;
            }
        }
        // Helper method for OnSelected -> gets new entity data from the tabcontrol and stores inside a new entity, 
        // that is then sent to the gamecontrol for
        // final processing + rendering
        private void GetNewEntity()
        {
            bool allValuesSetAndReal = false;
            foreach (TextBox textbox in numericControls)
            {
                allValuesSetAndReal = CheckForNumeric(textbox);
            }

            if (allValuesSetAndReal)
                if (enableGeoPlacement == true && tabState == TabState.GeometeryTab)
                {
                    Texture2D defaultTexture = gameControl1.DefaultTexture;

                    Entity newGeoEnt = new Entity(geoNameBox.Text);
                    newGeoEnt.AddProperty<Vector3>("Position", gameControl1.GetNewEntFinalPosition());
                    newGeoEnt.AddProperty<GraphicsDevice>("GraphicsDevice", gameControl1.GraphicsDevice);
                    newGeoEnt.AddProperty<ContentManager>("Content", gameControl1.ContentManager);
                    newGeoEnt.AddProperty<Vector3>("Scale", new Vector3(float.Parse(scaleXBox.Text), float.Parse(scaleYBox.Text), float.Parse(scaleZBox.Text)));
                    newGeoEnt.AddProperty<Vector3>("Rotation", new Vector3(float.Parse(geoRotBoxX.Text), float.Parse(geoRotBoxY.Text), float.Parse(geoRotBoxZ.Text)));

                    if (checkBox1.Checked)
                    {
                        newGeoEnt.AddProperty<BoundingBox>("BoundingBox", new BoundingBox());
                        newGeoEnt.AddBehaviour(new SimpleCollide());
                    }

                    if (geoType == Geometrytype.Rectangle)
                    {
                        newGeoEnt.AddProperty<Texture2D>("FrontTex", defaultTexture);
                        newGeoEnt.AddProperty<Texture2D>("BackTex", defaultTexture);
                        newGeoEnt.AddProperty<Texture2D>("RightTex", defaultTexture);
                        newGeoEnt.AddProperty<Texture2D>("LeftTex", defaultTexture);
                        newGeoEnt.AddProperty<Texture2D>("TopTex", defaultTexture);
                        newGeoEnt.AddProperty<Texture2D>("BottomTex", defaultTexture);
                        newGeoEnt.AddBehaviour(new Brush_Cube());
                    }
                    if (geoType == Geometrytype.Sphere)
                    {
                        throw new NotImplementedException();
                    }
                    gameControl1.AddEntToList(newGeoEnt);
                    newGeoEnt = null;
                }
                else
                    throw new DivideByZeroException("Something has gone horribly wrong!");
        }
        // Used to check if a textbox contains a numeric value, throws a messagebox if false;
        private bool CheckForNumeric(TextBox textbox)
        {
            string text = textbox.Text.Trim();
            double Num;
            bool isNum = double.TryParse(text, out Num);

            if (isNum)
                return true;
            else
                MessageBox.Show("Please enter a number " + textbox.Name);
            return false;
        }
        // Event handlers for menus:
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesForm.Show();
        }

        #endregion



    }
}
