using System;

namespace DN5 {
    [AttributeUsage(AttributeTargets.All)]
    public class CollidableAttribute : Attribute {
        // This constructor specifies the unnamed arguments to the attribute class.
        public CollidableAttribute(bool col) {
            this.isCollidable = col;
        }

        public CollidableAttribute() {
            this.isCollidable = true;
        }

        public override string ToString() {
            string value = "It is not collidable";
            if (isCollidable) {
                value = "It is collidable";
            }
            return value;
        }
        private bool isCollidable;
    }
}
