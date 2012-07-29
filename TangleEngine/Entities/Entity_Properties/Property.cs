using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TangleEngine.Entities.Entity_Properties
{
    public class Property<T>
    {
        public T Value { get; set; }

        public Property(T t)
        {
            this.Value = t;
        }
        public Entity Parent
        {
            get;
            private set;
        }

        public void Attach(Entity entity)
        {
            if (Parent != null)
                throw new InvalidOperationException("Cannot attach a property to two entities");

            Parent = entity;
        }
    }
}
