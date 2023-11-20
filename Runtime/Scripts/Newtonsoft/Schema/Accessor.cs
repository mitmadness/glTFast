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
    public class Accessor : AccessorBase<AccessorSparse>, IJsonObject
    {
        public JObject extras;
        public JObject extensions;

        [JsonProperty("type")]
        public string AccessorType { get; set; }

        [JsonExtensionData]
        IDictionary<string, JToken> m_JsonExtensionData;

        [Preserve]
        public Accessor() {}

        public override void SetAttributeType(GltfAccessorAttributeType attributeType)
        {
            base.SetAttributeType(attributeType);
            AccessorType = attributeType.ToString();
        }

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
