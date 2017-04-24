<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lease.aspx.cs" Inherits="RPMS_Web.Pages.Lease.Lease" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../../Content/Site.css" />
    <link rel="stylesheet" href="../../Content/bootstrap.css" />
    <link rel="stylesheet" href="../../Content/jquery-ui.css" />
    <script type="text/javascript" src="../../Scripts/Site.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-1.12.1.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap.js"></script>
    <title>Sigler Property Lease</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container body-content">
            <div class="letter-head">
                Sigler Properties, LLC
            </div>
            <div class="tac">
                P.O.Box 2281<br />
                Coppell, TX<br />
                (972) 951-3617<br />
                <h2>BASIC RENTAL AGREEMENT/RESIDENTIAL LEASE</h2>
            </div>
            <br />
            <br />
            <br />
            <div>
                <h4>LEASE AGREEMENT:</h4>
                <div>
                    Wade and Rachel Sigler, hereinafter referred to as Owner, hereby agree to lease to <asp:Literal runat="server" ID="litTenants" />
                    , hereinafter referred to as Tenant(s), the premises located at <asp:Literal runat="server" ID="litProperty" /> , hereinafter referred to as Premises. The term of the lease shall commence on
                    <asp:Literal runat="server" ID="litStartDate" /> and shall end on <asp:Literal runat="server" ID="litEndDate" />. Rent shall be $<asp:Literal runat="server" ID="litRent" /> a month. <asp:Literal runat="server" ID="litProratedRent" />
                    <br />
                    <br />
                    _______ Tenant(s) Initial
                </div>
                <br />
                <br />
            </div>
            <br />
            <div>
                <h4>SECURITY DEPOSIT:</h4>
                Tenant(s) <asp:Literal runat="server" ID="litTenants2" /> paid a nonrefundable security deposit of $<asp:Literal runat="server" ID="litDeposit" /> on <asp:Literal runat="server" ID="litDepositDate" /> for the purpose of guaranteeing compliance with the terms 
                of the lease. Owner may use part or all of the security deposit to repair any damage to the Premises caused by the Tenant(s), Tenant's family, agents and visitors to the Premise. However, 
                Owner is not just limited to the security deposit amount and Tenant(s) remains liable for any balance. Tenant(s) shall not apply or deduct any portion of any security deposit 
                from the last or any month's rent. Tenant(s) shall not use or apply any such security deposit at any time in lieu of payment of rent. If Tenant(s) breaches any terms or conditions of the Lease, Tenant(s) shall forfeit any deposit, as permitted by law.
                <br />
                <br />
                _______ Tenant(s) Initial
            </div>
            <br />
            <div>
                <h4>LEASE PAYMENTS:</h4>
                Rent is due on the first day of the calendar month which occupancy it covers. It shall be made payable to Sigler Properties. A late payment charge of $30.00 
                will also be due if the rent is not paid to Owners on the 5th of the month, an additional $5.00 per each additional day late. <b>*Late fees are strictly enforced.</b> Any 
                returned check will be subject to an additional fee of $35.00. If Tenant(s) occupies the premises beyond the term of this lease without agreement with the Owners then Tenant(s) will 
                be obligated to pay a full month rent payment.
                <br />
                <br />
                Certified letter is preferred if rent payment is mailed to address below. If check gets lost in the mail, it is the responsibility of the occupant to re-submit full rent payment.
                <br />Mail to:<br />
                <p>
                    Sigler Properties<br />
                    P.O. Box 2281<br />
                    Coppell, TX 75019<br />
                    (972)951-3617 (Rachel)<br />
                    (972)951-3618 (Wade)
                </p>
                <br />
                _______ Tenant(s) Initial
            </div>
            <br />
            <div>
                <h4>CONDITION OF PREMISES:</h4>
                Tenant(s) acknowledges that he/she has examined the premises and that said premises, all furnishings, fixtures, plumbing, heating, electrical facilities, all items provided by the Owner are clean, 
                and in satisfactory condition. Tenant(s) agrees to keep the premises and all items in good order 
                and good condition and to immediately pay for costs to repair and/or replace any portion of the above damage by Tenant(s), his/her guests and/or invitees, except as provided by law.
                <br />
                _______ Tenant(s) Initial
            </div>
            <div id='page-break-after-div' style='width: 100%;'></div>
            <br />
            <br />
            <br />
            <div>
                <h4>RESTRICTIONS ON USE:</h4>
                    No person other than <asp:Literal runat="server" ID="litNumAdults" /> adults, <asp:Literal runat="server" ID="litNumChildren" /> children 
                    and temporary guest may occupy the premises without written consent by the owners. 
                    If another person moves in then a new lease must be agreed to with additional rent of $25.00 per person. No more than <asp:Literal runat="server" ID="litNumberOfPeopleMax" /> people 
                    may occupy the property at one time. No verbal agreements to allow anyone other than Tenant(s) listed in this lease agreement to occupy the home. 
                    <b>Tenant(s) will be responsible for eviction fees if anyone other than the persons listed in this agreement must be evicted.</b>
                    <br/>
                    The Tenant(s) may not:
                    <ol type="1">
                        <li>
                            Negligently or intentionally damage the premises or permit them to be damaged.
                        </li>
                        <li>
                            Park or drive any motor vehicle on the lawn.
                        </li>
                        <li>
                            Do or permit any other act, which is detrimental to the welfare of the premises or the neighborhood.
                        </li>
                        <li>
                            Inoperable vehicles not to be left on the street or property for more than 7 days.
                        </li>
                    </ol>
                <br />
                _______ Tenant(s) Initial
            </div>
            <br />            
            <div>
                <h4>PROPERTY MAINTENANCE:</h4>
                Tenant(s) shall deposit all garbage and waste in a clean and sanitary manner into the proper receptacles and shall cooperate in keeping the garbage area neat and clean. Tenant(s) 
                shall be responsible for disposing of items of such size and nature as are not normally acceptable be the garbage hauler. Tenant(s) shall not paint, wallpaper, alter or 
                redecorate, change or install locks, screws, fastening devices, large nails, or adhesive materials, place signs, display or other exhibits, on or in any portion of the 
                premises without the written consent of the Owner.<br />
                Tenant(s) shall:
                <ol type="1">
                    <li>
                        Be responsible for keeping the kitchen and bathroom drains free of things that tend to cause clogging of the drain.
                    </li>
                    <li>
                        Tenant(s) shall pay for the cleaning out of plumbing fixtures that may need to be cleared of stoppage and for the expense or damage caused by stopping of waste pipes or overflow from bathtubs, wash basins, or sinks.
                    </li>
                    <li>
                        Tenant(s) shall pay for the complete replacement of windows should the Tenant(s) or guest of, damage and/or break one.
                    </li>
                    <li>
                        Tenant(s) is responsible for the changing of filters for the AC/Heater unit. Damages or repairs made due to Tenant(s) lack of regular maintenance will result in Tenant(s) paying for repairs.
                    </li>
                    <li>
                        Tenant(s) is responsible for any new pest control maintance
                    </li>
                </ol>
                <br />
                _______ Tenant(s) Initial
            </div>
            <br />
            <div>
                <h4>UTILITIES:</h4>
                Tenant(s) agrees to pay all utilities and/or services based upon occupancy of the premises. Trash pickup service is provided by the city on 
                <asp:Literal runat="server" ID="litTrashDay" /> of each week and the trashcan should be kept at the side or rear of the premises at all other times.
                <br />
                _______ Tenant(s) Initial
            </div>
            <br />
            <div>
                <h4>PETS:</h4>
                No pets unless a $<asp:Literal runat="server" ID="litPetDeposit" /> <i>PER PET DEPOSIT</i> is made along with the monthly rent and deposit. If Owner finds a 
                pet on the premises either visiting or permanent, Tenant(s) may be evicted or penalized the above listed deposit <b>IMMEDIATELY</b>.
                <br />
                <ol type="1">
                    <li>
                        Tenant(s) shall be liable for any damage or injury caused by the pet(s) and shall pay Owner any costs.                     </li>
                    <li>
                        Tenant(s) agrees to indemnify, hold harmless, and defend against liability, judgments, expense, or claims by third parties for injury to a person or damage to property caused 
                        by Tenant’s pet(s). Owner holds no liability for the actions of the Tenant's pet(s).
                    </li>
                    <li>
                         Tenant(s) agrees to clean up after their pet(s) and to dispose of their pet’s waste properly and promptly.
                    </li>
                    <li>
                        Tenant(s) agrees to keep their pet from being unnecessarily noisy or aggressive and causing an annoyance or discomfort to others and will promptly remedy any complaints made through the Owner.
                    </li>
                    <li>
                         Tenant(s) agrees that, if efforts to contact the Tenant(s) are unsuccessful, the Owner or Owner’s agent may enter the Tenant’s Premise if there is 
                        reasonable cause to believe an emergency situation exists with respect to the pet(s). If it becomes necessary for the pet to be put out on board, 
                        any and all costs incurred will be the responsibility of the Tenant(s).
                    </li>
                    <li>
                        Tenant(s) shall comply with all applicable laws, ordinances and regulations pertaining to pets and the keeping and care of animals.
                    </li>
                    <li>
                        In the event Owner, in his/her sole discretion, shall determine that it is in his best interest to revoke this agreement, he/she may do so on 30 days written notice 
                        to Tenant(s) to remove the pet. Tenant(s) shall permanently remove the pet from the premises within thirty days in compliance with such notice. The additional deposit posted 
                        in connection herewith shall remain a portion of the security deposit to be accounted for according to law upon vacation of the premises by Tenant(s)
                    </li>
                </ol>
                _______ Tenant(s) Initial
            </div>
            <div id='page-break-after-div' style='width: 100%;'></div>
            <br />
            <br />
            <br />
            <div>
                <h4>RIGHT OF ENTRY AND INSPECTION:</h4>
                Owner may enter, inspect, and/or repair the premises at any time, and may enter for the purpose of normal inspection and repairs, suspicion of illegal activity or access to Owner’s property. Owner is permitted to make all alterations, repairs, and maintenance.
                <br />
                _______ Tenant(s) Initial
            </div>
            <br />
            <div>
                <h4>INSURANCE:</h4>
                Tenant(s) acknowledges that Owners insurance <b>DOES NOT</b> cover personal property damage caused by fire, theft, rain, war, acts of god, acts of others, 
                and/or any other causes, nor shall Owner be held liable for such losses. Tenant(s) is advised to obtain his own insurance policy to cover any personal losses.
                <br />
                _______ Tenant(s) Initial
            </div>            
            <br />
            <div>
                <h4>APPLIANCES:</h4>
                The Premise contains the following appliances that the Tenant(s) may use but must leave when the lease has expired.
                <ul>
                    <li>Refrigerator</li>
                    <li>Stove</li>
                </ul>
                Repairs resulting less than $125.00 shall be deemed minor repairs. Should Tenant(s) neglect maintenance responsibilities, Owner or agent may assume them on Tenant's behalf 
                and any expenses incurred by Owner in connection therewith shall be additional rent (added rent), payable to Owner on demand. 
                <br />
                If Tenant(s) does not agree to be responsible for the appliances, but rather use his/her own, he/she may request that Owner's appliances be removed from the premises.                <br />
                _______ Tenant(s) Initial
            </div>
            <br />
            <div>
                <h4>ENTIRE AGREEMENT:</h4>
                This Agreement constitutes the entire agreement between Owner and Tenant(s). No oral agreements have been entered into and all modifications or notices shall be in writing 
                to be valid. The undersigned Tenant(s) have read and understood this Agreement and hereby acknowledge receipt of a copy of the Rental Agreement.
                <br />
                <br />
                <asp:Literal runat="server" ID="litSignatures" />
            </div>
        </div>
    </form>
</body>
</html>
