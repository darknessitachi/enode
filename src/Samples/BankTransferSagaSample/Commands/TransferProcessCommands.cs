﻿using System;
using BankTransferSagaSample.Domain;
using BankTransferSagaSample.Events;
using ENode.Commanding;

namespace BankTransferSagaSample.Commands {
    /// <summary>转账相关抽象命令基类
    /// </summary>
    [Serializable]
    public abstract class AbstractTransferCommand : Command {
        public Guid ProcessId { get; set; }
        public TransferInfo TransferInfo { get; set; }

        public AbstractTransferCommand(Guid processId) {
            ProcessId = processId;
        }
    }
    /// <summary>发起转账
    /// </summary>
    [Serializable]
    public class StartTransfer : AbstractTransferCommand {
        public StartTransfer() : base(Guid.NewGuid()) { }
    }
    /// <summary>转出
    /// </summary>
    [Serializable]
    public class TransferOut : AbstractTransferCommand {
        public TransferOut(Guid processId) : base(processId) { }
    }
    /// <summary>转入
    /// </summary>
    [Serializable]
    public class TransferIn : AbstractTransferCommand {
        public TransferIn(Guid processId) : base(processId) { }
    }
    /// <summary>回滚转出
    /// </summary>
    [Serializable]
    public class RollbackTransferOut : AbstractTransferCommand {
        public RollbackTransferOut(Guid processId) : base(processId) { }
    }
    /// <summary>处理已转出事件
    /// </summary>
    [Serializable]
    public class HandleTransferedOut : AbstractTransferCommand {
        public HandleTransferedOut(Guid processId) : base(processId) { }
    }
    /// <summary>处理已转入事件
    /// </summary>
    [Serializable]
    public class HandleTransferedIn : AbstractTransferCommand {
        public HandleTransferedIn(Guid processId) : base(processId) { }
    }
    /// <summary>处理“转出失败”
    /// </summary>
    [Serializable]
    public class HandleFailedTransferOut : AbstractTransferCommand {
        public Exception Exception { get; set; }
        public HandleFailedTransferOut(Guid processId) : base(processId) { }
    }
    /// <summary>处理“转入失败”
    /// </summary>
    [Serializable]
    public class HandleFailedTransferIn : AbstractTransferCommand {
        public Exception Exception { get; set; }
        public HandleFailedTransferIn(Guid processId) : base(processId) { }
    }
    /// <summary>处理转出已回滚事件
    /// </summary>
    [Serializable]
    public class HandleTransferOutRolledback : AbstractTransferCommand {
        public HandleTransferOutRolledback(Guid processId) : base(processId) { }
    }
}
