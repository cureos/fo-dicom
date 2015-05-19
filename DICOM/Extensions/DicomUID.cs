﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dicom
{
    public partial class DicomUID
    {
        public static string RootUID { get; set; }

        public static DicomUID Generate(string name = "")
        {
            if (string.IsNullOrEmpty(RootUID))
            {
                RootUID = "1.2.826.0.1.3680043.2.1343.1";
            }


            var uid = string.Format("{0}.{1}.{2}", RootUID, DateTime.UtcNow, DateTime.UtcNow.Ticks);

            return new DicomUID(uid, name, DicomUidType.SOPInstance);
        }
    }
}
