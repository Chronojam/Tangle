using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangleEngine.Entities.Entity_Behaviours;
using TangleEngine.Entities.Entity_Properties;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TangleEngine.Entities
{
    public class Entity
    {
        public string Name { get; private set; }
        public List<Behaviour> behaviours = new List<Behaviour>();
        public Dictionary<Type, Dictionary<string, object>> propertiesD = new Dictionary<Type, Dictionary<string, object>>();

        public Entity(string Name)
        {
            this.Name = Name;
        }
        public void AddBehaviour(Behaviour behaviour)
        {
            this.behaviours.Add(behaviour);
            behaviour.Attach(this);
        }

        public Property<T> AddProperty<T>(string name, T defaultValue = default(T))
        {
            Dictionary<string, object> props;
            if (!propertiesD.TryGetValue(typeof(T), out props))
            {
                props = new Dictionary<string, object>();
                propertiesD[typeof(T)] = props;
            }

            //if (props.ContainsKey(name))
                //throw new InvalidOperationException("Cannot add two properties with the same name and type");

                Property<T> property = new Property<T>(defaultValue);

                props[name] = property;
                property.Attach(this);

                return property;
        }

        public void Update()
        {
            int counter = 0;

            for (int i = 0; i < behaviours.Count; i++)
            {
                this.behaviours[counter].Update();
                counter++;
            }

        }
        public void Draw(GraphicsDevice device, Matrix World, Matrix View, Matrix Proj)
        {
            foreach (IDrawableBehaviour Drawables in behaviours.Where(a => a is IDrawableBehaviour))
            {
                Drawables.Draw(device, World, View, Proj);
            }
        }

        public Property<T> GetProperty<T>(string name)
        {

            Dictionary<string, object> Dic;
            object obj;

            if (propertiesD.TryGetValue(typeof(T),out Dic))
            {
                if (Dic.TryGetValue(name,out obj))
                {
                    return (Property<T>)obj;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        /*
         * HOW TO CALL BEHAVIOURS AND PROPERTIES.
            var renderables = Behaviours.Where(a => a.GetType() == typeof(Renderable));

            if (renderables.Any())
                renderables.First();
         * */
    }
}
