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

        /// <summary>
        /// The RGB components of the emissive color of the material.
        /// If an emissiveTexture is specified, this value is multiplied with the texel
        /// values.
        /// </summary>
        // Field is public for unified serialization only. Warn via Obsolete attribute.
        [Obsolete("Use Emissive for access.")]
        public new float[]? emissiveFactor = null;

        /// <summary>
        /// Emissive color of the material.
        /// </summary>
#if NEWTONSOFT_JSON
        [JsonIgnore]
#endif
        public new Color Emissive
        {
#pragma warning disable CS0618 // Type or member is obsolete
            get => emissiveFactor is null ? Color.black : new Color(
                emissiveFactor[0],
                emissiveFactor[1],
                emissiveFactor[2]
            );
            set => emissiveFactor = new[] { value.r, value.g, value.b };
#pragma warning restore CS0618 // Type or member is obsolete
        }

        /// <summary>
        /// Specifies the cutoff threshold when in `MASK` mode. If the alpha value is greater than
        /// or equal to this value then it is rendered as fully opaque, otherwise, it is rendered
        /// as fully transparent. This value is ignored for other modes.
        /// </summary>
        public new float? alphaCutoff = null;


        [JsonProperty("alphaMode")]
        public new string? AlphaMode = null;

        public JObject? extras = null;

        [JsonExtensionData]
        IDictionary<string, JToken>? m_JsonExtensionData = null;

        [Preserve]
        public Material() {}

        public override void SetAlphaMode(AlphaMode mode)
        {
            base.SetAlphaMode(mode);
            AlphaMode = mode.ToString().ToUpper();
        }

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
