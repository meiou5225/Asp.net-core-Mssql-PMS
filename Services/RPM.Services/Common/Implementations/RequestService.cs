﻿namespace RPM.Services.Common.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RPM.Data;
    using RPM.Data.Models;
    using RPM.Data.Models.Enums;
    using RPM.Services.Common.Models.Listing;
    using RPM.Services.Common.Models.Request;

    using static RPM.Common.GlobalConstants;

    public class RequestService : IRequestService
    {
        private readonly ApplicationDbContext context;
        private readonly IListingService listingService;

        public RequestService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateRequestAsync(RequestCreateServiceModel model)
        {
            var request = new Request
            {
                Date = model.Date,
                Type = model.Type,
                UserId = model.UserId,
                HomeId = model.HomeId,
                Message = model.Message,
                Document = model.Document,
                Status = (RequestStatus)Enum.Parse(typeof(RequestStatus), NA),
            };

            if (request == null)
            {
                return false;
            }

            await this.context.Requests.AddAsync(request);
            int result = await this.context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<RequestListServiceModel>> GetRequestsAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
