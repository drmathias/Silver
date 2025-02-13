﻿using Stratis.SmartContracts;
//@ using Microsoft.Contracts;

[Deploy]

public class SimpleTransfers : SmartContract
{
    public SimpleTransfers(ISmartContractState state)
        : base(state)
    {
        state.PersistentState.SetAddress(nameof(Owner), state.Message.Sender);
    }

    public void Donate()
    {
        //@ assume Microsoft.Contracts.Owner.Same(this, this.Owner);
        //@ Address owner = Owner;
        //@ ulong oldBalance = GetBalance(Owner);
        //@ ulong credit = Message.Value;

        ITransferResult result = this.Transfer(Owner, Message.Value);
        Assert(result.Success, "Transfer was not successful.");

        //@ assert GetBalance(owner) == oldBalance + credit;
    }

    private Address Owner
    {
        get => State.GetAddress(nameof(Owner));
        set => State.SetAddress(nameof(Owner), value);   
    }
}
