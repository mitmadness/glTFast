// SPDX-FileCopyrightText: 2023 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

#if NEWTONSOFT_JSON

using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace GLTFast.Newtonsoft.Schema
{
     /// <summary>
    /// Mesh vertex attribute collection. Each property value is the index of
    /// the accessor containing attribute’s data.
    /// </summary>
    [Serializable]
    public class Attributes : GLTFast.Schema.Attributes
    {
        // Names are identical to glTF specified property names, that's why
        // inconsistent names are ignored.
        // ReSharper disable InconsistentNaming

        /// <summary>Vertex position accessor index.</summary>
        public new int? POSITION;
        /// <summary>Vertex normals accessor index.</summary>
        public new int? NORMAL;
        /// <summary>Vertex tangents accessor index.</summary>
        public new int? TANGENT;
        /// <summary>Texture coordinates accessor index.</summary>
        public new int? TEXCOORD_0;
        /// <summary>Texture coordinates accessor index (second UV set).</summary>
        public new int? TEXCOORD_1;
        /// <summary>Texture coordinates accessor index (third UV set).</summary>
        public new int? TEXCOORD_2;
        /// <summary>Texture coordinates accessor index (fourth UV set).</summary>
        public new int? TEXCOORD_3;
        /// <summary>Texture coordinates accessor index (fifth UV set).</summary>
        public new int? TEXCOORD_4;
        /// <summary>Texture coordinates accessor index (sixth UV set).</summary>
        public new int? TEXCOORD_5;
        /// <summary>Texture coordinates accessor index (seventh UV set).</summary>
        public new int? TEXCOORD_6;
        /// <summary>Texture coordinates accessor index (eighth UV set).</summary>
        public new int? TEXCOORD_7;
        /// <summary>Texture coordinates accessor index (ninth UV set).</summary>
        public new int? TEXCOORD_8;
        /// <summary>Vertex color accessor index.</summary>
        public new int? COLOR_0;
        /// <summary>Bone joints accessor index.</summary>
        public new int? JOINTS_0;
        /// <summary>Bone weights accessor index.</summary>
        public new int? WEIGHTS_0;

        // ReSharper restore InconsistentNaming

        /// <summary>
        /// Determines whether two object instances are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var b = (Attributes)obj;
            return POSITION == b.POSITION
                && NORMAL == b.NORMAL
                && TANGENT == b.TANGENT
                && TEXCOORD_0 == b.TEXCOORD_0
                && TEXCOORD_1 == b.TEXCOORD_1
                && TEXCOORD_2 == b.TEXCOORD_2
                && TEXCOORD_3 == b.TEXCOORD_3
                && TEXCOORD_4 == b.TEXCOORD_4
                && TEXCOORD_5 == b.TEXCOORD_5
                && TEXCOORD_6 == b.TEXCOORD_6
                && TEXCOORD_7 == b.TEXCOORD_7
                && COLOR_0 == b.COLOR_0
                ;
        }

        /// <summary>
        /// Default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hash = 13;
            hash = hash * 7 + POSITION.GetHashCode();
            hash = hash * 7 + NORMAL.GetHashCode();
            hash = hash * 7 + TANGENT.GetHashCode();
            hash = hash * 7 + TEXCOORD_0.GetHashCode();
            hash = hash * 7 + TEXCOORD_1.GetHashCode();
            hash = hash * 7 + COLOR_0.GetHashCode();
            return hash;
        }
    }
}
#endif
