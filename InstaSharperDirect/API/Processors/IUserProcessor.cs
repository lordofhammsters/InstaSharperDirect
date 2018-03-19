﻿using System.Threading.Tasks;
using InstaSharper.Classes;
using InstaSharper.Classes.Models;

namespace InstaSharper.API.Processors
{
    public interface IUserProcessor
    {
        Task<IResult<InstaMediaList>> GetUserMediaAsync(long username, PaginationParameters paginationParameters);
        Task<IResult<InstaUser>> GetUserAsync(string username);
        Task<IResult<InstaCurrentUser>> GetUserByIdAsync(string pk);
        Task<IResult<InstaCurrentUser>> GetCurrentUserAsync();

        Task<IResult<InstaUserShortList>> GetUserFollowersAsync(string username,
            PaginationParameters paginationParameters);

        Task<IResult<InstaUserShortList>> GetUserFollowingAsync(string username,
            PaginationParameters paginationParameters);

        Task<IResult<InstaUserShortList>> GetCurrentUserFollowersAsync(PaginationParameters paginationParameters);
        Task<IResult<InstaMediaList>> GetUserTagsAsync(long username, PaginationParameters paginationParameters);
        Task<IResult<InstaFriendshipStatus>> FollowUserAsync(long userId);
        Task<IResult<InstaFriendshipStatus>> UnFollowUserAsync(long userId);
        Task<IResult<InstaFriendshipStatus>> BlockUserAsync(long userId);
        Task<IResult<InstaFriendshipStatus>> UnBlockUserAsync(long userId);
        Task<IResult<InstaFriendshipStatus>> GetFriendshipStatusAsync(long userId);
    }
}