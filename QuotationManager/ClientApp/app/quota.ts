export class Quota {
    constructor(
        public id?: number,
        public cityId?: number,
        public purposeId?: number,
        public refinancingAmount?: number,
        public comment?: string,
        public interestRate?: number,
        public quotaContributions?: [QuotaContribution]) { }
}

class QuotaContribution {
    constructor(
        public id?: number,
        public value?: number) { }
}