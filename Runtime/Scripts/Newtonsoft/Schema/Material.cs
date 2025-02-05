// SPDX-FileCopyrightText: 2023 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

#if NEWTONSOFT_JSON

#nullable enable

using System;
using System.Collections.Generic;

using GLTFast.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Scripting;

namespace GLTFast.Newtonsoft.Schema
{
    public class Material : MaterialBase<
        MaterialExtensions,
        NormalTextureInfo,
        OcclusionTextureInfo,
        PbrMetallicRoughness,
        TextureInfo,
        TextureInfoExtensions
    >, IJsonObject
    {
        public JObject? extras = null;

        [JsonExtensionData]
        IDictionary<string, JToken>? m_JsonExtensionData = null;

        [Preserve]
        public Material() {}

        public bool TryGetValue<T>(string key, out T value)
        {
            if (m_JsonExtensionData != null
                && m_JsonExtensionData.TryGetValue(key, out var token))
            {
                value = token.ToObject<T>()!;
                return true;
            }

            value = default!;
            return false;
        }
    }
}

#endif
