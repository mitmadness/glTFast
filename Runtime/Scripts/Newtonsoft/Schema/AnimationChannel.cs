// SPDX-FileCopyrightText: 2023 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

#if UNITY_ANIMATION && NEWTONSOFT_JSON

using System.Collections.Generic;

using GLTFast.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace GLTFast.Newtonsoft.Schema
{
    public class AnimationChannel : AnimationChannelBase<AnimationChannelTarget>, IJsonObject
    {
        public JObject extras;
        public JObject extensions;

        [JsonExtensionData]
        IDictionary<string, JToken> m_JsonExtensionData;

        [Preserve]
        public AnimationChannel() {}

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
