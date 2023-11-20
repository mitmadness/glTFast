// SPDX-FileCopyrightText: 2023 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

#if NEWTONSOFT_JSON

using System.Collections.Generic;

using GLTFast.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace GLTFast.Newtonsoft.Schema
{
    public class Node : NodeBase<NodeExtensions>, IJsonObject
    {
        /// <summary>
        /// The index of the mesh in this node.
        /// </summary>
        public new int? mesh;

        // /// <summary>
        // /// The weights of the instantiated Morph Target.
        // /// Number of elements must match number of Morph Targets of used mesh.
        // /// </summary>
        // public double[] weights;

        /// <summary>
        /// The index of the skin (in <see cref="RootBase.Skins"/> referenced by this node.
        /// </summary>
        public new int? skin;

        /// <summary>
        /// Camera index
        /// </summary>
        public new int? camera;

        public JObject extras;

        [JsonExtensionData]
        IDictionary<string, JToken> m_JsonExtensionData;

        [Preserve]
        public Node() {}

        public bool TryGetValue<T>(string key, out T value)
        {
            if (m_JsonExtensionData != null
                && m_JsonExtensionData.TryGetValue(key, out var token))
            {
                value = token.ToObject<T>();
                return true;
            }

            value = default;
            return false;
        }
    }
}

#endif
