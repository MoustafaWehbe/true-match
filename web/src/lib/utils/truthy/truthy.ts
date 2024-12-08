const isTruthy = <T>(x: any): x is NonNullable<T> => {
  if (x === undefined) return false;
  if (x === null) return false;
  if (typeof x === "string" && x.length === 0) return false;
  if (Array.isArray(x) && x.length === 0) return false;
  if (typeof x === "boolean") return x;
  return true;
};

export default isTruthy;
