﻿// Copyright (c) Barry Dorrans. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

using idunno.AtProto;

namespace idunno.Bluesky.Feed.Model
{
    internal class GetQuotesResponse
    {
        [JsonConstructor]
        public GetQuotesResponse(AtUri uri, Cid? cid, ICollection<PostView> posts, string? cursor)
        {
            Uri = uri;
            Cid = cid;
            Posts = posts;
            Cursor = cursor;
        }

        [JsonInclude]
        [JsonRequired]
        public AtUri Uri { get; init; }

        [JsonInclude]
        public Cid? Cid { get; init; }

        [JsonInclude]
        [JsonRequired]
        public ICollection<PostView> Posts { get; init; }

        [JsonInclude]
        public string? Cursor { get; init; }
    }
}