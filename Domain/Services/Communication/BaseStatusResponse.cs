using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services.Communication {
    public abstract class BaseStatusResponse<T> {

        public bool Status { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        public BaseStatusResponse(T ResourceIn) {
            Status = true;
            Message = string.Empty;
            Resource = ResourceIn;
        }

        public BaseStatusResponse(string MessageIn) {
            Status = false;
            Message = MessageIn;
            Resource = default;
        }
    }
}
