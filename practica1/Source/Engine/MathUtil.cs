using System;
using SFML.System;

namespace TCEngine
{
    public static class MathUtil
    {
        /** Constant for Degrees to Radians conversion*/
        public static float DEG2RAD = (float)(Math.PI / 180.0f);

        /** Constant for Radians to Degrees conversion*/
        public static float RAD2DEG = (float)(180.0f / Math.PI);

        /** Returns the Magnitude of the vector*/
        public static float Size(this Vector2f _vector)
        {
            return (float)Math.Sqrt(_vector.X * _vector.X + _vector.Y * _vector.Y);
        }

        /** Returns the normalized unit vector*/
        public static Vector2f Normal(this Vector2f _vector)
        {
            Vector2f result = _vector;

            float size = _vector.Size();
            if (size > 0.0f)
            {
                result.X /= size;
                result.Y /= size;
            }

            return result;
        }

        /** Rotates the vector angle Degrees*/
        public static Vector2f Rotate(this Vector2f _v, float _angle)
        {
            float sin0 = (float)Math.Sin(_angle * DEG2RAD);
            float cos0 = (float)Math.Cos(_angle * DEG2RAD);

            if (cos0 * cos0 < 0.001f * 0.001f)
                cos0 = 0.0f;

            Vector2f result = new Vector2f();
            result.X = cos0 * _v.X - sin0 * _v.Y;
            result.Y = sin0 * _v.X + cos0 * _v.Y;
            return result;
        }
    }
}
