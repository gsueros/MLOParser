using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataSource;

namespace PListLoader
{
    public sealed class DataSourceLoader
    {
        static int TEXT = 0;
        static int SIMPLE = 1;
        static int FULL = 2;
        static int MAP = 3;
        static int VIDEO = 4;

        static int VIEW360 = 5;
        static int SLIDER = 6;

        private static NSFrame StringToFrame(String frame)
        {
            NSFrame ret = new NSFrame();

            int indexX = frame.IndexOf("{{");
            int indexY = frame.IndexOf(",");

            int indexW1 = frame.IndexOf("}", indexY);
            int indexW2 = frame.IndexOf("}, {") + 3;

            string xval = frame.Substring(indexX + 2, indexY - 1);
            string yval = frame.Substring(indexY + 1, indexW1 - 1 - (indexY + 1) + 1);

            ret.X = Double.Parse(xval);
            ret.Y = Double.Parse(yval);

            int indexH = frame.IndexOf(",", indexW2);
            ret.Width = Double.Parse(frame.Substring(indexW2 + 1, (indexH - 1) - (indexW2 + 1) + 1));
            ret.Height = Double.Parse(frame.Substring(indexH + 1, (frame.Length - 2) - (indexH + 1)));
            return ret;
        }

        public static ChapterDataSource LoadChapterDataSource(string bookPath, string filepath)
        {

            List<SectionDataSource> sectionListDataSource = new List<SectionDataSource>();
            ChapterDataSource chapter = new ChapterDataSource();


            PList chapterIndex = new PList(filepath);
            List<dynamic> chapterList = chapterIndex["chapter"];
            foreach (PList sectionPlist in chapterList)
            {
                String sectionName = sectionPlist["sectionName"];
                List<dynamic> sectionList = sectionPlist["section"];

                List<PageDataSource> pageList = new List<PageDataSource>();
                SectionDataSource section = new SectionDataSource();
                section.Title = "Section1";

                foreach (PList pagePlist in sectionList)
                {
                    String contentDir = pagePlist["PageContentDir"];
                    contentDir += "/";
                    String pagePlistFile = bookPath + contentDir + "index.xml";

                    PageDataSource page = new PageDataSource();
                    page.ThumbSource = bookPath + contentDir + "thumbnail.jpg";
                    page.FullSource = bookPath + contentDir + "fullpage.jpg";
                    page.MediumSource = bookPath + contentDir + "medium.jpg";

                    PList plistlayers = new PList(pagePlistFile);
                    List<dynamic> layers = plistlayers["array"];
                    List<NSPage> slides = new List<NSPage>();

                    page.Slides = slides;
                    pageList.Add(page);

                    foreach (PList plist in layers)
                    {
                        NSPage slide = new NSPage();
                        slide.BackgroundFrame = StringToFrame(plist["frame"]);
                        slide.BackgroundImage = bookPath + contentDir + plist["image"];
                        slide.BackgroundImage = slide.BackgroundImage.Replace(".png", ".jpg");

                        List<NSLayer> AllLayers = new List<NSLayer>();
                        slide.Layers = AllLayers;


                        if (plist.ContainsKey("children") == true)
                        {
                            List<dynamic> sub_layers = plist["children"];
                            for (int j = 0; j < sub_layers.Count; j++)
                            {
                                PList child = sub_layers[j];

                                NSLayer layer = new NSLayer();
                                layer.ThumbFrame = StringToFrame(child["frame"]);
                                layer.ThumbPath = bookPath + contentDir + child["image"];

                                layer.ThumbPath = layer.ThumbPath.Replace(".png", ".jpg");
                                
                                if (child.ContainsKey("glosary"))
                                {
                                    List<dynamic> items = child["glosary"];


                                    if (items.Count == 2)
                                    {
                                        PList plistfull = child["glosary"][0];
                                        layer.Largeframe = StringToFrame(plistfull["frame"]);
                                        layer.LargePath = bookPath + contentDir + plistfull["text"];
                                        layer.LargePath = layer.LargePath.Replace(".png", ".jpg");

                                        plistfull = child["glosary"][1];
                                        layer.CroppedFrame = StringToFrame(plistfull["frame"]);


                                        if (pageList.Count < 6)
                                        {
                                            PageDataSource tmpPage = new PageDataSource();
                                            tmpPage.ThumbSource = layer.LargePath;
                                            tmpPage.FullSource = layer.LargePath;

                                            List<NSPage> tmpSlides = new List<NSPage>();
                                            NSPage slide_tmp = new NSPage();
                                            slide_tmp.BackgroundFrame = layer.Largeframe;
                                            slide_tmp.BackgroundImage = layer.LargePath;
                                            slide_tmp.Layers = new List<NSLayer>();
                                            tmpSlides.Add(slide_tmp);

                                            tmpPage.Slides = tmpSlides;
                                            pageList.Add(tmpPage);
                                        }
                                    }
                                    else if (items.Count == 1)
                                    {

                                        PList plistfull = child["glosary"][0];
                                        layer.Largeframe = StringToFrame(plistfull["frame"]);
                                        layer.LargePath = bookPath + contentDir + plistfull["text"];

                                        layer.CroppedFrame = null;

                                        if (layer.LargePath.Contains("map"))
                                        {
                                            layer.Type = MAP;
                                        }
                                        else if (layer.LargePath.Contains("video"))
                                        {
                                            layer.Type = VIDEO;
                                        }
                                        else if (layer.LargePath.Contains("slider"))
                                        {
                                            layer.Type = SLIDER;
                                        }
                                        else if (layer.LargePath.Contains("http"))
                                        {
                                            layer.Type = VIEW360;
                                            layer.LargePath = plistfull["text"];
                                        }

                                    }
                                    else if (items.Count == 3)
                                    {
                                        PList plistfull = child["glosary"][0];
                                        layer.Largeframe = StringToFrame(plistfull["frame"]);
                                        layer.LargePath = bookPath + contentDir + plistfull["text"];

                                        plistfull = child["glosary"][1];
                                        layer.CroppedFrame = StringToFrame(plistfull["frame"]);

                                        plistfull = child["glosary"][2];
                                        layer.Text = plistfull["text"];

                                        //layer.CroppedFrame = null;
                                        //layer.Largeframe = null;

                                    }
                                    else
                                    {
                                        layer.CroppedFrame = null;
                                        layer.Largeframe = null;
                                    }
                                }
                                if (layer.ThumbFrame != null)
                                {
                                    layer.ThumbPath = layer.ThumbPath.Replace(".png", ".jpg");
                                }
                                if (layer.LargePath != null)
                                {
                                    layer.LargePath = layer.LargePath.Replace(".png", ".jpg");
                                }
                                if (layer.Largeframe == null && layer.CroppedFrame == null) {
                                    layer.ThumbPath = layer.ThumbPath.Replace(".jpg", ".png");
                                }
                                AllLayers.Add(layer);
                            }
                        }
                        slides.Add(slide);
                    }

                }
                section.Pages = pageList;
                sectionListDataSource.Add(section);
            }

            chapter.Title = "Chapter 1";
            chapter.Sections = sectionListDataSource;


            return chapter;
        }


    }
}
