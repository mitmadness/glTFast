// SPDX-FileCopyrightText: 2023 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace GLTFast.Schema
{

    /// <summary>
    /// Assigns a light to a node
    /// </summary>
    [System.Serializable]
    public class NodeLightsPunctual
    {

        /// <summary>
        /// Light index
        /// </summary>
        public int? light;

        internal void GltfSerialize(JsonWriter writer)
        {
            writer.AddObject();
            if (light.HasValue)
            {
                writer.AddProperty("light", light.Value);
            }
            writer.Close();
        }
    }
}
