// SPDX-FileCopyrightText: 2023 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

#if NEWTONSOFT_JSON

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using GLTFast.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine.Scripting;

namespace GLTFast.Newtonsoft.Schema
{
    public class Root : RootBase<
        Accessor,
        Animation,
        Asset,
        Buffer,
        BufferView,
        Camera,
        RootExtensions,
        Image,
        Material,
        Mesh,
        Node,
        Sampler,
        Scene,
        Skin,
        Texture
    >, IJsonObject
    {
        public JObject extras;

        [JsonExtensionData]
        IDictionary<string, JToken> m_JsonExtensionData;

        [Preserve]
        public Root() {}

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

        public void GltfSerializeWithNewtonSoft(StreamWriter stream)
        {
            var options = new JsonSerializerSettings
            {
                ContractResolver = new WritablePropertiesOnlyResolver(),
                NullValueHandling = NullValueHandling.Ignore,
            };

            var json = JsonConvert.SerializeObject(this, options);
            stream.Write(json);
        }
    }

    // Source: https://stackoverflow.com/questions/18543482/is-there-a-way-to-ignore-get-only-properties-in-json-net-without-using-jsonignor/18548894#18548894
    public class WritablePropertiesOnlyResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            return props.Where(p => p.Writable).ToList();
        }
    }
}

#endif
