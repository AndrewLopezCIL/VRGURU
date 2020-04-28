using Chapter4CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chapter4CodeFirst.DAL
{
    public class VRInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VRContext>
    {
         
            protected override void Seed(VRContext context)
            {
                var students = new List<StoresModels>
            {
            new StoresModels{StoreID = 1, StoreName = "BestBuy"},
            new StoresModels{StoreID = 2, StoreName = "Valve"},
            new StoresModels{StoreID = 3, StoreName = "Gamestop"},
            new StoresModels{StoreID = 4, StoreName = "Oculus.com"},
            new StoresModels{StoreID = 5, StoreName = "Amazon"},
            new StoresModels{StoreID = 6, StoreName = "Newegg"},
            new StoresModels{StoreID = 7, StoreName = "Ebay"},
            new StoresModels{StoreID = 8, StoreName = "Walmart"}
            };

                students.ForEach(s => context.StoresModels.Add(s));
                context.SaveChanges();
                var courses = new List<VRHeadsetModels>
            {
            new VRHeadsetModels{HeadsetID = 1,HeadsetName = "Valve Index" ,AvailableStoreName = "Valve", Price = 1600 }, 
            new VRHeadsetModels{HeadsetID = 2, HeadsetName = "HTC Vive", AvailableStoreName = "Amazon", Price = 800 }, 
            new VRHeadsetModels{HeadsetID = 3, HeadsetName = "Oculus: Rift S",AvailableStoreName = "BestBuy", Price = 400 }, 
            new VRHeadsetModels{HeadsetID = 4, HeadsetName = "Oculus: Rift CV1",AvailableStoreName = "Oculus.com", Price = 400 }, 
            new VRHeadsetModels{HeadsetID = 5, HeadsetName = "Samsung Mobile VR",AvailableStoreName = "Walmart", Price = 25 }, 
            new VRHeadsetModels{HeadsetID = 6, HeadsetName = "Windows Mixed Reality",AvailableStoreName = "Newegg", Price = 200}, 
            new VRHeadsetModels{HeadsetID = 7,HeadsetName = "Oculus: Quest", AvailableStoreName = "Oculus.com", Price = 200 }, 
            new VRHeadsetModels{HeadsetID = 8, HeadsetName = "Sony Playstation VR",AvailableStoreName = "Gamestop", Price = 276}
            };
                courses.ForEach(s => context.VRHeadsetModels.Add(s));
                context.SaveChanges();
            var enrollments = new List<BundlesModels>
            {
            new BundlesModels{BundleID = 1, BundledItem = "External Sensor", HeadsetBundledID = 1},
            new BundlesModels{BundleID = 2, BundledItem = "Game: Onward", HeadsetBundledID = 2},
            new BundlesModels{BundleID = 3, BundledItem = "Game: Pavlov VR", HeadsetBundledID = 3},
            new BundlesModels{BundleID = 4, BundledItem = "Game: Minecraft VR", HeadsetBundledID = 4},
            new BundlesModels{BundleID = 5, BundledItem = "Game: Onward + External Sensor", HeadsetBundledID = 1},
            new BundlesModels{BundleID = 6, BundledItem = "Game: Onward + Pavlov VR", HeadsetBundledID = 6},
            new BundlesModels{BundleID = 7, BundledItem = "Three Random Games", HeadsetBundledID = 7},
            new BundlesModels{BundleID = 8, BundledItem = "Two External Sensors", HeadsetBundledID = 2}
            };
                enrollments.ForEach(s => context.BundlesModels.Add(s));
                context.SaveChanges();
            }
        } 
    }