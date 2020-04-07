﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System.Linq;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests.Shared
{
    public partial class MagickImageTests
    {
        [TestClass]
        public class TheAttributeNamesMethod
        {
            [TestMethod]
            public void ShouldReturnTheAttributeNames()
            {
                using (IMagickImage image = new MagickImage(Files.ImageMagickJPG))
                {
                    image.SetAttribute("foo", "bar");
                    image.SetArtifact("bar", "foo");

                    var names = image.AttributeNames;
                    Assert.AreEqual(5, names.Count());
                    Assert.AreEqual("date:create,date:modify,foo,jpeg:colorspace,jpeg:sampling-factor", string.Join(",", (from name in names
                                                                                                                           orderby name
                                                                                                                           select name).ToArray()));
                }
            }
        }
    }
}