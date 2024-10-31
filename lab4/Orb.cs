using System;
using System.Collections.Generic;
using System.Drawing;
using DN3;

namespace DN4 {
    public abstract class Orb {
        public const double G = 30; //6.673e-11
        private const double dt = 1.5;
        protected Bitmap bitmap;
        private Vector pos;
        private Vector v;
        private string name;
        private double mass;

        // Delegate and Event for Collision
        public delegate void CollisionHandler(Orb o1);
        public event CollisionHandler Collision;

        public Vector Pos {
            get { return pos; }
            set { pos = value; }
        }

        public Vector Velocity {
            get { return v; }
            set { v = value; }
        }

        public double Mass {
            get { return mass; }
            set { mass = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public Orb(string name, double x, double y, double vx, double vy, double m) {
            Pos = new Vector(x, y, 0);
            v = new Vector(vx, vy, 0);
            mass = m;
            this.name = name;
        }

        public virtual void CalcVelocity(IList<Orb> space) {
            Vector a = new Vector(0, 0, 0); //für Gesamtbeschleunigung
            foreach (Orb orb in space) {
                if (orb != this) {
                    Vector abstand = orb.Pos - Pos;
                    double radius = (double)abstand;

                    // Prüfen, ob der Abstand < 15 Pixel ist und Collision Event auslösen
                    if (radius < 15) {
                        if (this.Mass < orb.Mass) {
                            Collision?.Invoke(this); // Event für den leichteren Himmelskörper auslösen
                        } else {
                            Collision?.Invoke(orb); // Event für den anderen Himmelskörper auslösen
                        }
                    }

                    // Gravitation
                    a += (G * orb.Mass / (radius * radius * radius)) * abstand;
                }
            }
            v = v + a;
        }

        public void Move() {
            Pos += v * dt;
        }

        public abstract void Draw(Graphics g);
    }
}
