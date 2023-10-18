import {
  BanknotesIcon,
  UserPlusIcon,
  UserIcon,
  ChartBarIcon,
} from "@heroicons/react/24/solid";

export const statisticsCardsData = [
  {
    color: "blue",
    icon: UserPlusIcon,
    title: "Today's Users",
    value: "1",
    footer: {
      color: "text-green-500",
      value: "Today's",
      label: "sign ups",
    },
  },
  {
    color: "pink",
    icon: UserIcon,
    title: "Users",
    value: "5",
    footer: {
      color: "text-green-500",
      value: "Total",
      label: "users",
    },
  },
  {
    color: "green",
    icon: BanknotesIcon,
    title: "Today's Sales",
    value: "$20",
    footer: {
      color: "text-red-500",
      value: "Today's",
      label: "venue",
    },
  },
  {
    color: "orange",
    icon: ChartBarIcon,
    title: "Sales",
    value: "$2400",
    footer: {
      color: "text-green-500",
      value: "Total",
      label: "venue",
    },
  },
];



export default statisticsCardsData;
