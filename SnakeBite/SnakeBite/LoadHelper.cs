using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace SnakeBite
{
    static class LoadHelper
    {
        public static Dictionary<TextureEnum, Texture2D> Textures;
        public static Dictionary<LetterEnum, Texture2D> Letters;

        public static Dictionary<NumberEnum, Texture2D> Numbers;
        public static Dictionary<SoundEnum, SoundEffect> Sounds;
        public static Dictionary<FontEnum, SpriteFont> Fonts;

        public static List<string> Chaptures;
        private static void LoadChapters()
        {
            using (StreamReader reader = new StreamReader("chaptures.txt"))
            {
                Console.WriteLine("STORY OPENNED");
                string line = reader.ReadLine();
                while (line != null)
                {
                    Chaptures.Add(line);
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }

        public static void Load(ContentManager content)
        {
            Fonts = new Dictionary<FontEnum, SpriteFont>();
            Textures = new Dictionary<TextureEnum, Texture2D>();

            Letters = new Dictionary<LetterEnum, Texture2D>();
            Numbers = new Dictionary<NumberEnum, Texture2D>();
            Chaptures = new List<string>();
            LoadChapters();
            Sounds = new Dictionary<SoundEnum, SoundEffect>();

            Textures.Add(TextureEnum.cage, content.Load<Texture2D>(@"GRAPHICS\cage"));
            Textures.Add(TextureEnum.bird, content.Load<Texture2D>(@"GRAPHICS\bird"));
            Textures.Add(TextureEnum.bg, content.Load<Texture2D>(@"GRAPHICS\bg"));
            Textures.Add(TextureEnum.bird_leg, content.Load<Texture2D>(@"GRAPHICS\bird_leg"));
            Textures.Add(TextureEnum.snake_body, content.Load<Texture2D>(@"GRAPHICS\snake_body"));
            Textures.Add(TextureEnum.snake_head, content.Load<Texture2D>(@"GRAPHICS\snake_head"));
            Textures.Add(TextureEnum.upper_jaw, content.Load<Texture2D>(@"GRAPHICS\upper_jaw"));
            Textures.Add(TextureEnum.lower_jaw, content.Load<Texture2D>(@"GRAPHICS\lower_jaw"));
            Textures.Add(TextureEnum.logo, content.Load<Texture2D>(@"GRAPHICS\logo"));
            Textures.Add(TextureEnum.button_start, content.Load<Texture2D>(@"GRAPHICS\button_start"));
            Textures.Add(TextureEnum.button_exit, content.Load<Texture2D>(@"GRAPHICS\button_exit"));

            Textures.Add(TextureEnum.fanfare, content.Load<Texture2D>(@"GRAPHICS\fanfare"));
            Textures.Add(TextureEnum.star, content.Load<Texture2D>(@"GRAPHICS\star"));
            Textures.Add(TextureEnum.star_small, content.Load<Texture2D>(@"GRAPHICS\star_small"));
            Textures.Add(TextureEnum.dock, content.Load<Texture2D>(@"GRAPHICS\dock"));

            Textures.Add(TextureEnum.puff, content.Load<Texture2D>(@"GRAPHICS\puff"));
            Textures.Add(TextureEnum.chapter, content.Load<Texture2D>(@"GRAPHICS\chapter"));
            Textures.Add(TextureEnum.blood, content.Load<Texture2D>(@"GRAPHICS\blood"));
            Textures.Add(TextureEnum.outro, content.Load<Texture2D>(@"GRAPHICS\outro"));





            Letters.Add(LetterEnum.A, content.Load<Texture2D>(@"GRAPHICS\LETTERS\A"));
            Letters.Add(LetterEnum.B, content.Load<Texture2D>(@"GRAPHICS\LETTERS\B"));
            Letters.Add(LetterEnum.C, content.Load<Texture2D>(@"GRAPHICS\LETTERS\C"));
            Letters.Add(LetterEnum.D, content.Load<Texture2D>(@"GRAPHICS\LETTERS\D"));
            Letters.Add(LetterEnum.E, content.Load<Texture2D>(@"GRAPHICS\LETTERS\E"));
            Letters.Add(LetterEnum.F, content.Load<Texture2D>(@"GRAPHICS\LETTERS\F"));
            Letters.Add(LetterEnum.G, content.Load<Texture2D>(@"GRAPHICS\LETTERS\G"));
            Letters.Add(LetterEnum.H, content.Load<Texture2D>(@"GRAPHICS\LETTERS\H"));
            Letters.Add(LetterEnum.I, content.Load<Texture2D>(@"GRAPHICS\LETTERS\I"));
            Letters.Add(LetterEnum.J, content.Load<Texture2D>(@"GRAPHICS\LETTERS\J"));
            Letters.Add(LetterEnum.K, content.Load<Texture2D>(@"GRAPHICS\LETTERS\K"));
            Letters.Add(LetterEnum.L, content.Load<Texture2D>(@"GRAPHICS\LETTERS\L"));
            Letters.Add(LetterEnum.M, content.Load<Texture2D>(@"GRAPHICS\LETTERS\M"));
            Letters.Add(LetterEnum.N, content.Load<Texture2D>(@"GRAPHICS\LETTERS\N"));
            Letters.Add(LetterEnum.O, content.Load<Texture2D>(@"GRAPHICS\LETTERS\O"));
            Letters.Add(LetterEnum.P, content.Load<Texture2D>(@"GRAPHICS\LETTERS\P"));
            Letters.Add(LetterEnum.Q, content.Load<Texture2D>(@"GRAPHICS\LETTERS\Q"));
            Letters.Add(LetterEnum.R, content.Load<Texture2D>(@"GRAPHICS\LETTERS\R"));
            Letters.Add(LetterEnum.S, content.Load<Texture2D>(@"GRAPHICS\LETTERS\S"));
            Letters.Add(LetterEnum.T, content.Load<Texture2D>(@"GRAPHICS\LETTERS\T"));
            Letters.Add(LetterEnum.U, content.Load<Texture2D>(@"GRAPHICS\LETTERS\U"));
            Letters.Add(LetterEnum.V, content.Load<Texture2D>(@"GRAPHICS\LETTERS\V"));
            Letters.Add(LetterEnum.W, content.Load<Texture2D>(@"GRAPHICS\LETTERS\W"));
            Letters.Add(LetterEnum.X, content.Load<Texture2D>(@"GRAPHICS\LETTERS\X"));
            Letters.Add(LetterEnum.Y, content.Load<Texture2D>(@"GRAPHICS\LETTERS\Y"));
            Letters.Add(LetterEnum.Z, content.Load<Texture2D>(@"GRAPHICS\LETTERS\Z"));
            Letters.Add(LetterEnum.dot, content.Load<Texture2D>(@"GRAPHICS\LETTERS\dot"));
            Letters.Add(LetterEnum.comma, content.Load<Texture2D>(@"GRAPHICS\LETTERS\comma"));
            Letters.Add(LetterEnum.space, content.Load<Texture2D>(@"GRAPHICS\LETTERS\space"));
            Letters.Add(LetterEnum.emotion_mark, content.Load<Texture2D>(@"GRAPHICS\LETTERS\emotion_mark"));
            Letters.Add(LetterEnum.question_mark, content.Load<Texture2D>(@"GRAPHICS\LETTERS\question_mark"));



            Numbers.Add(NumberEnum.num_0, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\0"));
            Numbers.Add(NumberEnum.num_1, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\1"));
            Numbers.Add(NumberEnum.num_2, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\2"));
            Numbers.Add(NumberEnum.num_3, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\3"));
            Numbers.Add(NumberEnum.num_4, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\4"));
            Numbers.Add(NumberEnum.num_5, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\5"));
            Numbers.Add(NumberEnum.num_6, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\6"));
            Numbers.Add(NumberEnum.num_7, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\7"));
            Numbers.Add(NumberEnum.num_8, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\8"));
            Numbers.Add(NumberEnum.num_9, content.Load<Texture2D>(@"GRAPHICS\NUMBERS\9"));

            Sounds.Add(SoundEnum.dun_dun_dun, content.Load<SoundEffect>(@"SOUNDS\dun_dun_dun"));
            Sounds.Add(SoundEnum.birdie, content.Load<SoundEffect>(@"SOUNDS\birdie"));
            Sounds.Add(SoundEnum.letter_down, content.Load<SoundEffect>(@"SOUNDS\letter_down"));
            Sounds.Add(SoundEnum.fanfare, content.Load<SoundEffect>(@"SOUNDS\fanfare"));

            Sounds.Add(SoundEnum.birdies_bg, content.Load<SoundEffect>(@"SOUNDS\birdies_bg"));
           

            #region load fonts
            Fonts.Add(FontEnum.Arial22, content.Load<SpriteFont>(@"Fonts\Arial22"));
            Fonts.Add(FontEnum.Arial42, content.Load<SpriteFont>(@"Fonts\Arial42"));
            Fonts.Add(FontEnum.Arial, content.Load<SpriteFont>(@"Fonts\Arial"));
            #endregion
           
        }
    }

    public enum SongEnum
    {
    }

    public enum ButtonEnum
    {
    }

    public enum BackgroundEnum
    {

    }

    public enum NumberEnum
    {
        num_0,
        num_1,
        num_2,
        num_3,
        num_4,
        num_5,
        num_6,
        num_7,
        num_8,
        num_9
    }

    public enum SoundEnum
    {
        dun_dun_dun,
        birdie,
        birdies_bg,
        letter_down,
        fanfare
    }
    public enum FontEnum
    {
        Arial22,
        Arial42,
        Arial
    }
    public enum LetterEnum
    {
        A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,
        dot, comma, emotion_mark, question_mark, space
    }
    public enum TextureEnum
    {
        bg,
        cage,
        bird,
        bird_leg,
        snake_body,
        snake_head,
        logo,
        upper_jaw,
        lower_jaw,
        chapter,
        button_exit,
        button_start,
        button_continue,
        dock,
        blood,
        fanfare,
        star,
        star_small,
        puff,
        outro
    }

}
