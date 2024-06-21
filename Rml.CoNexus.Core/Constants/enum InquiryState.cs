namespace Rml.CoNexus.Core.Constants;

public enum InquiryState : byte
{
    SETUP,      // no participation allowed, this is time for data entry and configuration
    OPEN,       // participation starts, people can work on their next uncompleted step in the process
    CLOSED,     // participation ends, read/only time starts
    ARCHIVED    // not sure what to do here except lock the door
}

