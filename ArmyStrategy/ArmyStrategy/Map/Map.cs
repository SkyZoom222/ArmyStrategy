using Android.Service.QuickSettings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyStrategy.ArmyStrategy
{
    internal class Map
    {
        string ObjectsavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Map Creator");
        string TilesavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Map Creator");
        int[,] TileId;
        int[,] ObjectId;

        int W, H;
        Texture2D __mapT;
        public List<Rectangle> Objects { get; private set; } = new List<Rectangle>();
        

        public Map(int Width, int Height, Texture2D MapTexture, List<Rectangle> MapObjects)
        {
            W = Width;
            H = Height;
            __mapT = MapTexture;
            Objects = MapObjects;
        }



        public void DeleteObj(int id)
        {
            Objects.RemoveAt(id);
        }

        //Тут сохранение мб :) -_- '-' *__* XD $_$ 0_-
        public async void LoadToId(int loadedsave)
        {
            ObjectsavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Map Creator");
            TilesavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Map Creator");


            try
            {
/*                loadedsave = 1;*/
                TilesavePath = Path.Combine(TilesavePath, $"Map{loadedsave}Tile.txt");
                using (StreamReader outputFile = new StreamReader(TilesavePath, false))
                {
                    for (int gridY = 0; gridY < TileId.GetLength(1); gridY++)
                    {
                        string line = await outputFile.ReadLineAsync();
                        for (int gridX = 0; gridX < TileId.GetLength(0); gridX++)
                        {
                            TileId[gridX, gridY] = Convert.ToInt32(line.Split(" ")[gridX]);
                        }
                    }
                }

                ObjectsavePath = Path.Combine(ObjectsavePath, $"Map{loadedsave}Object.txt");
                using (StreamReader outputFile = new StreamReader(ObjectsavePath, false))
                {
                    for (int gridY = 0; gridY < ObjectId.GetLength(1); gridY++)
                    {
                        string line = await outputFile.ReadLineAsync();
                        for (int gridX = 0; gridX < ObjectId.GetLength(0); gridX++)
                        {
                            ObjectId[gridX, gridY] = Convert.ToInt32(line.Split(" ")[gridX]);
                        }
                    }
                }

            }
            catch
            {
                await MessageBox.Show("The selected map does not exist", "OK???", new[] { "OK", "OK", "OK" });
                //Exit();
            }

        }

    }
}
