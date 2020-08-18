using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TGC.MonoGame.Samples.Cameras;

namespace TGC.MonoGame.Samples.Geometries
{
    /// <summary>
    /// The quad is like a plane but its made by two triangle and the surface is oriented in the XY plane of the local coordinate space.
    /// </summary>
    public class QuadPrimitive
    {
        private const int NumberOfVertices = 4;
        private const int NumberOfIndices = 6;

        /// <summary>
        /// Create a textured quad.
        /// </summary>
        /// <param name="device">Used to initialize and control the presentation of the graphics device.</param>
        /// <param name="origin">The center.</param>
        /// <param name="normal">Normal vector.</param>
        /// <param name="up">Up vector.</param>
        /// <param name="width">The Width.</param>
        /// <param name="height">The High.</param>
        /// <param name="texture">The texture to use.</param>
        /// <param name="textureRepeats">Times to repeat the given texture.</param>
        public QuadPrimitive(GraphicsDevice device, Vector3 origin, Vector3 normal, Vector3 up, float width, float height,
            Texture2D texture, float textureRepeats)
        {
            Effect = new BasicEffect(device);
            Effect.TextureEnabled = true;
            Effect.Texture = texture;

            Vertices = new VertexPositionNormalTexture[NumberOfVertices];
            Indexes = new short[NumberOfIndices];
            Origin = origin;
            Normal = normal;
            Up = up;

            // Calculate the quad corners
            Left = Vector3.Cross(normal, Up);
            var upperCenter = Up * height / 2 + origin;
            UpperLeft = upperCenter + Left * width / 2;
            UpperRight = upperCenter - Left * width / 2;
            LowerLeft = UpperLeft - Up * height;
            LowerRight = UpperRight - Up * height;

            FillVertices(textureRepeats);
        }

        /// <summary>
        /// Array of vertex positions and texture.
        /// </summary>
        private VertexPositionNormalTexture[] Vertices { get; }

        /// <summary>
        ///  The indexes fot the vertex buffer, using clockwise winding.
        /// </summary>
        private short[] Indexes { get; }

        /// <summary>
        /// The left direction.
        /// </summary>
        private Vector3 Left { get; }

        /// <summary>
        /// The lower left corner.
        /// </summary>
        private Vector3 LowerLeft { get; }

        /// <summary>
        /// The lower right corner.
        /// </summary>
        private Vector3 LowerRight { get; }

        /// <summary>
        /// The normal direction.
        /// </summary>
        private Vector3 Normal { get; }

        /// <summary>
        /// The center.
        /// </summary>
        private Vector3 Origin { get; }

        /// <summary>
        /// The up direction.
        /// </summary>
        private Vector3 Up { get; }

        /// <summary>
        /// The up left corner.
        /// </summary>
        private Vector3 UpperLeft { get; }

        /// <summary>
        /// The up right corner.
        /// </summary>
        private Vector3 UpperRight { get; }

        /// <summary>
        /// Built-in effect that supports optional texturing, vertex coloring, fog, and lighting.
        /// </summary>
        private BasicEffect Effect { get; }

        /// <summary>
        /// Create a vertex buffer for the figure with the given information.
        /// </summary>
        /// <param name="textureRepeats">Times to repeat the given texture.</param>
        private void FillVertices(float textureRepeats)
        {
            // Fill in texture coordinates to display full texture on quad
            var textureUpperLeft = Vector2.Zero;
            var textureUpperRight = Vector2.UnitX;
            var textureLowerLeft = Vector2.UnitY;
            var textureLowerRight = Vector2.One;

            // Provide a normal for each vertex
            for (var i = 0; i < Vertices.Length; i++) Vertices[i].Normal = Normal;

            // Set the position and texture coordinate for each vertex
            Vertices[0].Position = LowerLeft;
            Vertices[0].TextureCoordinate = textureLowerLeft * textureRepeats;
            Vertices[1].Position = UpperLeft;
            Vertices[1].TextureCoordinate = textureUpperLeft * textureRepeats;
            Vertices[2].Position = LowerRight;
            Vertices[2].TextureCoordinate = textureLowerRight * textureRepeats;
            Vertices[3].Position = UpperRight;
            Vertices[3].TextureCoordinate = textureUpperRight * textureRepeats;

            // Set the index buffer for each vertex, using clockwise winding
            Indexes[0] = 0;
            Indexes[1] = 1;
            Indexes[2] = 2;
            Indexes[3] = 2;
            Indexes[4] = 1;
            Indexes[5] = 3;
        }

        /// <summary>
        /// Draw the quad.
        /// </summary>
        /// <param name="graphicsDevice">The device where to draw.</param>
        /// <param name="camera">The camera contains the necessary matrices.</param>
        public void Draw(GraphicsDevice graphicsDevice, Camera camera)
        {
            Effect.World = camera.WorldMatrix * Matrix.CreateRotationX(-MathHelper.PiOver2);
            Effect.View = camera.ViewMatrix;
            Effect.Projection = camera.ProjectionMatrix;

            foreach (var pass in Effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, Vertices, 0, NumberOfVertices,
                    Indexes, 0, 2);
            }
        }
    }
}