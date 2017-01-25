﻿/* Copyright (c) Citrix Systems, Inc. 
 * All rights reserved. 
 * 
 * Redistribution and use in source and binary forms, 
 * with or without modification, are permitted provided 
 * that the following conditions are met: 
 * 
 * *   Redistributions of source code must retain the above 
 *     copyright notice, this list of conditions and the 
 *     following disclaimer. 
 * *   Redistributions in binary form must reproduce the above 
 *     copyright notice, this list of conditions and the 
 *     following disclaimer in the documentation and/or other 
 *     materials provided with the distribution. 
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND 
 * CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
 * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR 
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
 * BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE 
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF 
 * SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace XenAdmin.Core
{
    public class PropertyManager
    {
        // resource file with internationalized display strings
        public static System.Resources.ResourceManager FriendlyNames = new System.Resources.ResourceManager("XenAdmin.FriendlyNames", typeof(PropertyManager).Assembly);

        /// <summary>
        /// Returns null if no match is found.
        /// </summary>
        public static string GetFriendlyName(string s)
        {
            string result = FriendlyNames.GetString(s);
#if DEBUG
			Debug.Assert(result != null, string.Format("{0} doesn't exist in FriendlyNames", s));
#endif
            return result;
        }

        /// <summary>
        /// Return the result of GetFriendlyName(s), or GetFriendlyName(defkey) if the former returns null.
        /// Returns null if no match is found for defkey.
        /// </summary>
        public static string GetFriendlyName(string s, string defkey)
        {
            string result = FriendlyNames.GetString(s) ?? FriendlyNames.GetString(defkey);
#if DEBUG
			Debug.Assert(result != null, string.Format("{0} doesn't exist in FriendlyNames", s));
#endif
            return result;
        }

        /// <summary>
        /// Returns true if this culture is loaded
        /// </summary>
        public static bool IsCultureLoaded(CultureInfo ci)
        {
            return FriendlyNames.GetResourceSet(ci, false, false) != null;
        }
    }
}
