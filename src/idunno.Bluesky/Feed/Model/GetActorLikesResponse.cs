﻿// Copyright (c) Barry Dorrans. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace idunno.Bluesky.Feed.Model
{
    [SuppressMessage("Performance", "CA1812", Justification = "Used in GetActorLikes.")]
    internal sealed record GetActorLikesResponse
    {
        [JsonConstructor]
        internal GetActorLikesResponse(ICollection<FeedViewPost> feed, string? cursor)
        {
            Feed = feed;
            Cursor = cursor;
        }

        [JsonInclude]
        [JsonRequired]
        public ICollection<FeedViewPost> Feed { get; init; }

        [JsonInclude]
        public string? Cursor { get; init; }
    }
}
