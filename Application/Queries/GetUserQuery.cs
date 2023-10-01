﻿using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public class GetUserQuery : IRequest<UsersResultDTO>
    {
    }
}
