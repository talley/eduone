using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne
{
    public static class ThemeManager
    {

        public static List<string> Availables()
        {

            var result = new List<string>
            {
               "Aqua",
               "Breeze",
                "CrystalDark",
                 "Crystal",
                 "Desert",
                   "FluentDark",
                    "Fluent",
                     "MaterialPink",
                      "MaterialTeal",
                       "Material",
                        "Office2007Black",
                         "Office2007Silver",
                          "Office2010Black",
                           "Office2010Blue",
                            "Office2010Silver",
                             "Office2013Dark",
                              "Office2013Light",
                               "Office2019Dark",
                                "Office2019Gray",
                                 "Office2019Light",
                                  "TelerikMetroBlue",
                                   "TelerikMetro",
                                    "TelerikMetroTouch",
                                     "VisualStudio2012Dark",
                                      "VisualStudio2012Light",
                                       "VisualStudio2022Light",
                                        "Windows11",
                                         "Windows7",
                                          "Windows8"
            };

            return result;
        }
    }
}
