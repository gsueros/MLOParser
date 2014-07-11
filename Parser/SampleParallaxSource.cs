using System;
using System.Collections.Generic;

namespace PListLoader
{
    public sealed class SampleParallaxSource
    {


        public SampleParallaxSource()
        {
        }

        public IList<String> getlevelone()
        {
             List<String> LevelOne =  new List<string>();
            for (int j = 0; j < 8; j++)
                LevelOne.Add("ms-appx:///sampledata/1/" + (int)j + ".png");
            return LevelOne ;
        }


          public IList<String> getlevelTwo()
        {
             List<String> LevelOne =  new List<string>();
            for (int j = 0; j < 12; j++)
                LevelOne.Add("ms-appx:///sampledata/2/" + (int)j + ".png");
            return LevelOne ;
        }

          public IList<String> getlevelthree()
        {
             List<String> LevelOne =  new List<string>();
            for (int j = 0; j < 12; j++)
                LevelOne.Add("ms-appx:///sampledata/3/" + (int)j + ".png");
            return LevelOne ;
        }
        
    }
}
