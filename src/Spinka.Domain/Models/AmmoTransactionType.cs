using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class AmmoTransactionType : BaseEntity
    {
        public string Name { get; set; }
        public string Acronym { get; set; }

        private ISet<AmmoTransaction> _ammoTransactions = new HashSet<AmmoTransaction>();
        public IEnumerable<AmmoTransaction> AmmoTransactions => _ammoTransactions;
    }
}