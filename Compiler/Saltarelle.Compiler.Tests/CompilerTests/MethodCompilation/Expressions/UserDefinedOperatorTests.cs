﻿using NUnit.Framework;
using Saltarelle.Compiler.ScriptSemantics;

namespace Saltarelle.Compiler.Tests.CompilerTests.MethodCompilation.Expressions {
	[TestFixture]
	public class UserDefinedOperatorTests : MethodCompilerTestBase {
		[Test]
		public void UserDefinedBinaryOperatorsWork() {
			AssertCorrect(@"
class C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
	public static bool operator>(C1 c1, C1 c2) { return false; }
	public static bool operator<(C1 c1, C1 c2) { return false; }
	public static bool operator>=(C1 c1, C1 c2) { return false; }
	public static bool operator<=(C1 c1, C1 c2) { return false; }
	public static bool operator==(C1 c1, C1 c2) { return false; }
	public static bool operator!=(C1 c1, C1 c2) { return false; }
}
void M() {
	C1 x = null, y = null, z;
	int i = 0;
	bool b;
	// BEGIN
	z = x +  y;
	z = x -  y;
	z = x *  y;
	z = x /  y;
	z = x %  y;
	z = x &  y;
	z = x |  y;
	z = x ^  y;
	z = x << i;
	z = x >> i;
	b = x >  y;
	b = x <  y;
	b = x >= y;
	b = x <= y;
	b = x == y;
	b = x != y;
	// END
}",
@"	$z = {sm_C1}.$op_Addition($x, $y);
	$z = {sm_C1}.$op_Subtraction($x, $y);
	$z = {sm_C1}.$op_Multiply($x, $y);
	$z = {sm_C1}.$op_Division($x, $y);
	$z = {sm_C1}.$op_Modulus($x, $y);
	$z = {sm_C1}.$op_BitwiseAnd($x, $y);
	$z = {sm_C1}.$op_BitwiseOr($x, $y);
	$z = {sm_C1}.$op_ExclusiveOr($x, $y);
	$z = {sm_C1}.$op_LeftShift($x, $i);
	$z = {sm_C1}.$op_RightShift($x, $i);
	$b = {sm_C1}.$op_GreaterThan($x, $y);
	$b = {sm_C1}.$op_LessThan($x, $y);
	$b = {sm_C1}.$op_GreaterThanOrEqual($x, $y);
	$b = {sm_C1}.$op_LessThanOrEqual($x, $y);
	$b = {sm_C1}.$op_Equality($x, $y);
	$b = {sm_C1}.$op_Inequality($x, $y);
");
		}

		[Test]
		public void UserDefinedBinaryOperatorsWorkStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
	public static bool operator>(C1 c1, C1 c2) { return false; }
	public static bool operator<(C1 c1, C1 c2) { return false; }
	public static bool operator>=(C1 c1, C1 c2) { return false; }
	public static bool operator<=(C1 c1, C1 c2) { return false; }
	public static bool operator==(C1 c1, C1 c2) { return false; }
	public static bool operator!=(C1 c1, C1 c2) { return false; }
}
void M() {
	C1 x = default(C1), y = default(C1), z;
	int i = 0;
	bool b;
	// BEGIN
	z = x +  y;
	z = x -  y;
	z = x *  y;
	z = x /  y;
	z = x %  y;
	z = x &  y;
	z = x |  y;
	z = x ^  y;
	z = x << i;
	z = x >> i;
	b = x >  y;
	b = x <  y;
	b = x >= y;
	b = x <= y;
	b = x == y;
	b = x != y;
	// END
}",
@"	$z = {sm_C1}.$op_Addition($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$z = {sm_C1}.$op_Subtraction($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$z = {sm_C1}.$op_Multiply($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$z = {sm_C1}.$op_Division($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$z = {sm_C1}.$op_Modulus($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$z = {sm_C1}.$op_BitwiseAnd($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$z = {sm_C1}.$op_BitwiseOr($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$z = {sm_C1}.$op_ExclusiveOr($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$z = {sm_C1}.$op_LeftShift($Clone($x, {to_C1}), $Clone($i, {to_Int32}));
	$z = {sm_C1}.$op_RightShift($Clone($x, {to_C1}), $Clone($i, {to_Int32}));
	$b = {sm_C1}.$op_GreaterThan($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$b = {sm_C1}.$op_LessThan($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$b = {sm_C1}.$op_GreaterThanOrEqual($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$b = {sm_C1}.$op_LessThanOrEqual($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$b = {sm_C1}.$op_Equality($Clone($x, {to_C1}), $Clone($y, {to_C1}));
	$b = {sm_C1}.$op_Inequality($Clone($x, {to_C1}), $Clone($y, {to_C1}));
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedUserDefinedBinaryOperatorsWork() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
	public static bool operator>(C1 c1, C1 c2) { return false; }
	public static bool operator<(C1 c1, C1 c2) { return false; }
	public static bool operator>=(C1 c1, C1 c2) { return false; }
	public static bool operator<=(C1 c1, C1 c2) { return false; }
	public static bool operator==(C1 c1, C1 c2) { return false; }
	public static bool operator!=(C1 c1, C1 c2) { return false; }
}
void M() {
	C1? x = null, y = null, z;
	int? i = null;
	bool b;
	// BEGIN
	z = x +  y;
	z = x -  y;
	z = x *  y;
	z = x /  y;
	z = x %  y;
	z = x &  y;
	z = x |  y;
	z = x ^  y;
	z = x << i;
	z = x >> i;
	b = x >  y;
	b = x <  y;
	b = x >= y;
	b = x <= y;
	b = x == y;
	b = x != y;
	// END
}",
@"	$z = $Lift({sm_C1}.$op_Addition($x, $y), Regular);
	$z = $Lift({sm_C1}.$op_Subtraction($x, $y), Regular);
	$z = $Lift({sm_C1}.$op_Multiply($x, $y), Regular);
	$z = $Lift({sm_C1}.$op_Division($x, $y), Regular);
	$z = $Lift({sm_C1}.$op_Modulus($x, $y), Regular);
	$z = $Lift({sm_C1}.$op_BitwiseAnd($x, $y), Regular);
	$z = $Lift({sm_C1}.$op_BitwiseOr($x, $y), Regular);
	$z = $Lift({sm_C1}.$op_ExclusiveOr($x, $y), Regular);
	$z = $Lift({sm_C1}.$op_LeftShift($x, $i), Regular);
	$z = $Lift({sm_C1}.$op_RightShift($x, $i), Regular);
	$b = $Lift({sm_C1}.$op_GreaterThan($x, $y), Comparison);
	$b = $Lift({sm_C1}.$op_LessThan($x, $y), Comparison);
	$b = $Lift({sm_C1}.$op_GreaterThanOrEqual($x, $y), Comparison);
	$b = $Lift({sm_C1}.$op_LessThanOrEqual($x, $y), Comparison);
	$b = $Lift({sm_C1}.$op_Equality($x, $y), Equality);
	$b = $Lift({sm_C1}.$op_Inequality($x, $y), Inequality);
");
		}

		[Test]
		public void LiftedUserDefinedBinaryOperatorsWorkStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
	public static bool operator>(C1 c1, C1 c2) { return false; }
	public static bool operator<(C1 c1, C1 c2) { return false; }
	public static bool operator>=(C1 c1, C1 c2) { return false; }
	public static bool operator<=(C1 c1, C1 c2) { return false; }
	public static bool operator==(C1 c1, C1 c2) { return false; }
	public static bool operator!=(C1 c1, C1 c2) { return false; }
}
void M() {
	C1? x = null, y = null, z;
	int? i = null;
	bool b;
	// BEGIN
	z = x +  y;
	z = x -  y;
	z = x *  y;
	z = x /  y;
	z = x %  y;
	z = x &  y;
	z = x |  y;
	z = x ^  y;
	z = x << i;
	z = x >> i;
	b = x >  y;
	b = x <  y;
	b = x >= y;
	b = x <= y;
	b = x == y;
	b = x != y;
	// END
}",
@"	$z = $Lift({sm_C1}.$op_Addition($Clone($x, {to_C1}), $Clone($y, {to_C1})), Regular);
	$z = $Lift({sm_C1}.$op_Subtraction($Clone($x, {to_C1}), $Clone($y, {to_C1})), Regular);
	$z = $Lift({sm_C1}.$op_Multiply($Clone($x, {to_C1}), $Clone($y, {to_C1})), Regular);
	$z = $Lift({sm_C1}.$op_Division($Clone($x, {to_C1}), $Clone($y, {to_C1})), Regular);
	$z = $Lift({sm_C1}.$op_Modulus($Clone($x, {to_C1}), $Clone($y, {to_C1})), Regular);
	$z = $Lift({sm_C1}.$op_BitwiseAnd($Clone($x, {to_C1}), $Clone($y, {to_C1})), Regular);
	$z = $Lift({sm_C1}.$op_BitwiseOr($Clone($x, {to_C1}), $Clone($y, {to_C1})), Regular);
	$z = $Lift({sm_C1}.$op_ExclusiveOr($Clone($x, {to_C1}), $Clone($y, {to_C1})), Regular);
	$z = $Lift({sm_C1}.$op_LeftShift($Clone($x, {to_C1}), $Clone($i, {to_Int32})), Regular);
	$z = $Lift({sm_C1}.$op_RightShift($Clone($x, {to_C1}), $Clone($i, {to_Int32})), Regular);
	$b = $Lift({sm_C1}.$op_GreaterThan($Clone($x, {to_C1}), $Clone($y, {to_C1})), Comparison);
	$b = $Lift({sm_C1}.$op_LessThan($Clone($x, {to_C1}), $Clone($y, {to_C1})), Comparison);
	$b = $Lift({sm_C1}.$op_GreaterThanOrEqual($Clone($x, {to_C1}), $Clone($y, {to_C1})), Comparison);
	$b = $Lift({sm_C1}.$op_LessThanOrEqual($Clone($x, {to_C1}), $Clone($y, {to_C1})), Comparison);
	$b = $Lift({sm_C1}.$op_Equality($Clone($x, {to_C1}), $Clone($y, {to_C1})), Equality);
	$b = $Lift({sm_C1}.$op_Inequality($Clone($x, {to_C1}), $Clone($y, {to_C1})), Inequality);
", mutableValueTypes: true);
		}

		[Test]
		public void CompoundAssignmentWithUserDefinedBinaryOperatorsWork() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1 x = default(C1), y = default(C1);
	int i = 0;
	// BEGIN
	x +=  y;
	x -=  y;
	x *=  y;
	x /=  y;
	x %=  y;
	x &=  y;
	x |=  y;
	x ^=  y;
	x <<= i;
	x >>= i;
	// END
}",
@"	$x = {sm_C1}.$op_Addition($x, $y);
	$x = {sm_C1}.$op_Subtraction($x, $y);
	$x = {sm_C1}.$op_Multiply($x, $y);
	$x = {sm_C1}.$op_Division($x, $y);
	$x = {sm_C1}.$op_Modulus($x, $y);
	$x = {sm_C1}.$op_BitwiseAnd($x, $y);
	$x = {sm_C1}.$op_BitwiseOr($x, $y);
	$x = {sm_C1}.$op_ExclusiveOr($x, $y);
	$x = {sm_C1}.$op_LeftShift($x, $i);
	$x = {sm_C1}.$op_RightShift($x, $i);
");
		}

		[Test]
		public void CompoundAssignmentWithUserDefinedBinaryOperatorsWorkStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1 x = default(C1), y = default(C1);
	int i = 0;
	// BEGIN
	x +=  y;
	x -=  y;
	x *=  y;
	x /=  y;
	x %=  y;
	x &=  y;
	x |=  y;
	x ^=  y;
	x <<= i;
	x >>= i;
	// END
}",
@"	$x = {sm_C1}.$op_Addition($x, $Clone($y, {to_C1}));
	$x = {sm_C1}.$op_Subtraction($x, $Clone($y, {to_C1}));
	$x = {sm_C1}.$op_Multiply($x, $Clone($y, {to_C1}));
	$x = {sm_C1}.$op_Division($x, $Clone($y, {to_C1}));
	$x = {sm_C1}.$op_Modulus($x, $Clone($y, {to_C1}));
	$x = {sm_C1}.$op_BitwiseAnd($x, $Clone($y, {to_C1}));
	$x = {sm_C1}.$op_BitwiseOr($x, $Clone($y, {to_C1}));
	$x = {sm_C1}.$op_ExclusiveOr($x, $Clone($y, {to_C1}));
	$x = {sm_C1}.$op_LeftShift($x, $Clone($i, {to_Int32}));
	$x = {sm_C1}.$op_RightShift($x, $Clone($i, {to_Int32}));
", mutableValueTypes: true);
		}

		[Test]
		public void CompoundAssignmentToThisWithUserDefinedBinaryOperatorsWorksStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }

void M() {
	C1 y = default(C1);
	int i = 0;
	// BEGIN
	this +=  y;
	this -=  y;
	this *=  y;
	this /=  y;
	this %=  y;
	this &=  y;
	this |=  y;
	this ^=  y;
	this <<= i;
	this >>= i;
	// END
}
}",
@"	$ShallowCopy({sm_C1}.$op_Addition(this, $Clone($y, {to_C1})), this);
	$ShallowCopy({sm_C1}.$op_Subtraction(this, $Clone($y, {to_C1})), this);
	$ShallowCopy({sm_C1}.$op_Multiply(this, $Clone($y, {to_C1})), this);
	$ShallowCopy({sm_C1}.$op_Division(this, $Clone($y, {to_C1})), this);
	$ShallowCopy({sm_C1}.$op_Modulus(this, $Clone($y, {to_C1})), this);
	$ShallowCopy({sm_C1}.$op_BitwiseAnd(this, $Clone($y, {to_C1})), this);
	$ShallowCopy({sm_C1}.$op_BitwiseOr(this, $Clone($y, {to_C1})), this);
	$ShallowCopy({sm_C1}.$op_ExclusiveOr(this, $Clone($y, {to_C1})), this);
	$ShallowCopy({sm_C1}.$op_LeftShift(this, $Clone($i, {to_Int32})), this);
	$ShallowCopy({sm_C1}.$op_RightShift(this, $Clone($i, {to_Int32})), this);
", mutableValueTypes: true, addSkeleton: false);
		}

		[Test]
		public void CompoundAssignmentToThisWithUserDefinedBinaryOperatorsWorksWhenUsingTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }

void M() {
	C1 x = default(C1), y = default(C1);
	int i = 0;
	// BEGIN
	x = this +=  y;
	x = this -=  y;
	x = this *=  y;
	x = this /=  y;
	x = this %=  y;
	x = this &=  y;
	x = this |=  y;
	x = this ^=  y;
	x = this <<= i;
	x = this >>= i;
	// END
}
}",
@"	$ShallowCopy({sm_C1}.$op_Addition(this, $Clone($y, {to_C1})), this);
	$x = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_Subtraction(this, $Clone($y, {to_C1})), this);
	$x = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_Multiply(this, $Clone($y, {to_C1})), this);
	$x = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_Division(this, $Clone($y, {to_C1})), this);
	$x = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_Modulus(this, $Clone($y, {to_C1})), this);
	$x = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_BitwiseAnd(this, $Clone($y, {to_C1})), this);
	$x = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_BitwiseOr(this, $Clone($y, {to_C1})), this);
	$x = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_ExclusiveOr(this, $Clone($y, {to_C1})), this);
	$x = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_LeftShift(this, $Clone($i, {to_Int32})), this);
	$x = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_RightShift(this, $Clone($i, {to_Int32})), this);
	$x = $Clone(this, {to_C1});
", mutableValueTypes: true, addSkeleton: false);
		}

		[Test]
		public void CompoundAssignmentToAVariableWithUserDefinedBinaryOperatorsAssigningTheResultWorks() {
			AssertCorrect(@"
class C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1 x = null, y = null, z = null;
	int i = 0;
	// BEGIN
	z = x +=  y;
	z = x -=  y;
	z = x *=  y;
	z = x /=  y;
	z = x %=  y;
	z = x &=  y;
	z = x |=  y;
	z = x ^=  y;
	z = x <<= i;
	z = x >>= i;
	// END
}",
@"	$z = $x = {sm_C1}.$op_Addition($x, $y);
	$z = $x = {sm_C1}.$op_Subtraction($x, $y);
	$z = $x = {sm_C1}.$op_Multiply($x, $y);
	$z = $x = {sm_C1}.$op_Division($x, $y);
	$z = $x = {sm_C1}.$op_Modulus($x, $y);
	$z = $x = {sm_C1}.$op_BitwiseAnd($x, $y);
	$z = $x = {sm_C1}.$op_BitwiseOr($x, $y);
	$z = $x = {sm_C1}.$op_ExclusiveOr($x, $y);
	$z = $x = {sm_C1}.$op_LeftShift($x, $i);
	$z = $x = {sm_C1}.$op_RightShift($x, $i);
");
		}

		[Test]
		public void CompoundAssignmentToAVariableWithUserDefinedBinaryOperatorsAssigningTheResultWorksStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1 x = default(C1), y = default(C1), z = default(C1);
	int i = 0;
	// BEGIN
	z = x +=  y;
	z = x -=  y;
	z = x *=  y;
	z = x /=  y;
	z = x %=  y;
	z = x &=  y;
	z = x |=  y;
	z = x ^=  y;
	z = x <<= i;
	z = x >>= i;
	// END
}",
@"	$x = {sm_C1}.$op_Addition($x, $Clone($y, {to_C1}));
	$z = $Clone($x, {to_C1});
	$x = {sm_C1}.$op_Subtraction($x, $Clone($y, {to_C1}));
	$z = $Clone($x, {to_C1});
	$x = {sm_C1}.$op_Multiply($x, $Clone($y, {to_C1}));
	$z = $Clone($x, {to_C1});
	$x = {sm_C1}.$op_Division($x, $Clone($y, {to_C1}));
	$z = $Clone($x, {to_C1});
	$x = {sm_C1}.$op_Modulus($x, $Clone($y, {to_C1}));
	$z = $Clone($x, {to_C1});
	$x = {sm_C1}.$op_BitwiseAnd($x, $Clone($y, {to_C1}));
	$z = $Clone($x, {to_C1});
	$x = {sm_C1}.$op_BitwiseOr($x, $Clone($y, {to_C1}));
	$z = $Clone($x, {to_C1});
	$x = {sm_C1}.$op_ExclusiveOr($x, $Clone($y, {to_C1}));
	$z = $Clone($x, {to_C1});
	$x = {sm_C1}.$op_LeftShift($x, $Clone($i, {to_Int32}));
	$z = $Clone($x, {to_C1});
	$x = {sm_C1}.$op_RightShift($x, $Clone($i, {to_Int32}));
	$z = $Clone($x, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void CompoundAssignmentToAPropertyWithUserDefinedBinaryOperatorsAssigningTheResultWorks() {
			AssertCorrect(@"
class C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
C1 P { get; set; }
void M() {
	C1 y = default(C1), z = default(C1);
	int i = 0;
	// BEGIN
	z = P +=  y;
	z = P -=  y;
	z = P *=  y;
	z = P /=  y;
	z = P %=  y;
	z = P &=  y;
	z = P |=  y;
	z = P ^=  y;
	z = P <<= i;
	z = P >>= i;
	// END
}",
@"	var $tmp1 = {sm_C1}.$op_Addition(this.get_$P(), $y);
	this.set_$P($tmp1);
	$z = $tmp1;
	var $tmp2 = {sm_C1}.$op_Subtraction(this.get_$P(), $y);
	this.set_$P($tmp2);
	$z = $tmp2;
	var $tmp3 = {sm_C1}.$op_Multiply(this.get_$P(), $y);
	this.set_$P($tmp3);
	$z = $tmp3;
	var $tmp4 = {sm_C1}.$op_Division(this.get_$P(), $y);
	this.set_$P($tmp4);
	$z = $tmp4;
	var $tmp5 = {sm_C1}.$op_Modulus(this.get_$P(), $y);
	this.set_$P($tmp5);
	$z = $tmp5;
	var $tmp6 = {sm_C1}.$op_BitwiseAnd(this.get_$P(), $y);
	this.set_$P($tmp6);
	$z = $tmp6;
	var $tmp7 = {sm_C1}.$op_BitwiseOr(this.get_$P(), $y);
	this.set_$P($tmp7);
	$z = $tmp7;
	var $tmp8 = {sm_C1}.$op_ExclusiveOr(this.get_$P(), $y);
	this.set_$P($tmp8);
	$z = $tmp8;
	var $tmp9 = {sm_C1}.$op_LeftShift(this.get_$P(), $i);
	this.set_$P($tmp9);
	$z = $tmp9;
	var $tmp10 = {sm_C1}.$op_RightShift(this.get_$P(), $i);
	this.set_$P($tmp10);
	$z = $tmp10;
");
		}

		[Test]
		public void CompoundAssignmentToAPropertyWithUserDefinedBinaryOperatorsAssigningTheResultWorksStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
C1 P { get; set; }
void M() {
	C1 y = default(C1), z = default(C1);
	int i = 0;
	// BEGIN
	z = P +=  y;
	z = P -=  y;
	z = P *=  y;
	z = P /=  y;
	z = P %=  y;
	z = P &=  y;
	z = P |=  y;
	z = P ^=  y;
	z = P <<= i;
	z = P >>= i;
	// END
}",
@"	var $tmp1 = {sm_C1}.$op_Addition(this.get_$P(), $Clone($y, {to_C1}));
	this.set_$P($Clone($tmp1, {to_C1}));
	$z = $Clone($tmp1, {to_C1});
	var $tmp2 = {sm_C1}.$op_Subtraction(this.get_$P(), $Clone($y, {to_C1}));
	this.set_$P($Clone($tmp2, {to_C1}));
	$z = $Clone($tmp2, {to_C1});
	var $tmp3 = {sm_C1}.$op_Multiply(this.get_$P(), $Clone($y, {to_C1}));
	this.set_$P($Clone($tmp3, {to_C1}));
	$z = $Clone($tmp3, {to_C1});
	var $tmp4 = {sm_C1}.$op_Division(this.get_$P(), $Clone($y, {to_C1}));
	this.set_$P($Clone($tmp4, {to_C1}));
	$z = $Clone($tmp4, {to_C1});
	var $tmp5 = {sm_C1}.$op_Modulus(this.get_$P(), $Clone($y, {to_C1}));
	this.set_$P($Clone($tmp5, {to_C1}));
	$z = $Clone($tmp5, {to_C1});
	var $tmp6 = {sm_C1}.$op_BitwiseAnd(this.get_$P(), $Clone($y, {to_C1}));
	this.set_$P($Clone($tmp6, {to_C1}));
	$z = $Clone($tmp6, {to_C1});
	var $tmp7 = {sm_C1}.$op_BitwiseOr(this.get_$P(), $Clone($y, {to_C1}));
	this.set_$P($Clone($tmp7, {to_C1}));
	$z = $Clone($tmp7, {to_C1});
	var $tmp8 = {sm_C1}.$op_ExclusiveOr(this.get_$P(), $Clone($y, {to_C1}));
	this.set_$P($Clone($tmp8, {to_C1}));
	$z = $Clone($tmp8, {to_C1});
	var $tmp9 = {sm_C1}.$op_LeftShift(this.get_$P(), $Clone($i, {to_Int32}));
	this.set_$P($Clone($tmp9, {to_C1}));
	$z = $Clone($tmp9, {to_C1});
	var $tmp10 = {sm_C1}.$op_RightShift(this.get_$P(), $Clone($i, {to_Int32}));
	this.set_$P($Clone($tmp10, {to_C1}));
	$z = $Clone($tmp10, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void CompoundAssignmentToAFieldWithUserDefinedBinaryOperatorsAssigningTheResultWorks() {
			AssertCorrect(@"
class C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
C1 x;
void M() {
	C1 y = null, z = null;
	int i = 0;
	// BEGIN
	z = x +=  y;
	z = x -=  y;
	z = x *=  y;
	z = x /=  y;
	z = x %=  y;
	z = x &=  y;
	z = x |=  y;
	z = x ^=  y;
	z = x <<= i;
	z = x >>= i;
	// END
}",
@"	$z = this.$x = {sm_C1}.$op_Addition(this.$x, $y);
	$z = this.$x = {sm_C1}.$op_Subtraction(this.$x, $y);
	$z = this.$x = {sm_C1}.$op_Multiply(this.$x, $y);
	$z = this.$x = {sm_C1}.$op_Division(this.$x, $y);
	$z = this.$x = {sm_C1}.$op_Modulus(this.$x, $y);
	$z = this.$x = {sm_C1}.$op_BitwiseAnd(this.$x, $y);
	$z = this.$x = {sm_C1}.$op_BitwiseOr(this.$x, $y);
	$z = this.$x = {sm_C1}.$op_ExclusiveOr(this.$x, $y);
	$z = this.$x = {sm_C1}.$op_LeftShift(this.$x, $i);
	$z = this.$x = {sm_C1}.$op_RightShift(this.$x, $i);
");
		}

		[Test]
		public void CompoundAssignmentToAFieldWithUserDefinedBinaryOperatorsAssigningTheResultWorksStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
C1 x;
void M() {
	C1 y = default(C1), z = default(C1);
	int i = 0;
	// BEGIN
	z = x +=  y;
	z = x -=  y;
	z = x *=  y;
	z = x /=  y;
	z = x %=  y;
	z = x &=  y;
	z = x |=  y;
	z = x ^=  y;
	z = x <<= i;
	z = x >>= i;
	// END
}",
@"	this.$x = {sm_C1}.$op_Addition(this.$x, $Clone($y, {to_C1}));
	$z = $Clone(this.$x, {to_C1});
	this.$x = {sm_C1}.$op_Subtraction(this.$x, $Clone($y, {to_C1}));
	$z = $Clone(this.$x, {to_C1});
	this.$x = {sm_C1}.$op_Multiply(this.$x, $Clone($y, {to_C1}));
	$z = $Clone(this.$x, {to_C1});
	this.$x = {sm_C1}.$op_Division(this.$x, $Clone($y, {to_C1}));
	$z = $Clone(this.$x, {to_C1});
	this.$x = {sm_C1}.$op_Modulus(this.$x, $Clone($y, {to_C1}));
	$z = $Clone(this.$x, {to_C1});
	this.$x = {sm_C1}.$op_BitwiseAnd(this.$x, $Clone($y, {to_C1}));
	$z = $Clone(this.$x, {to_C1});
	this.$x = {sm_C1}.$op_BitwiseOr(this.$x, $Clone($y, {to_C1}));
	$z = $Clone(this.$x, {to_C1});
	this.$x = {sm_C1}.$op_ExclusiveOr(this.$x, $Clone($y, {to_C1}));
	$z = $Clone(this.$x, {to_C1});
	this.$x = {sm_C1}.$op_LeftShift(this.$x, $Clone($i, {to_Int32}));
	$z = $Clone(this.$x, {to_C1});
	this.$x = {sm_C1}.$op_RightShift(this.$x, $Clone($i, {to_Int32}));
	$z = $Clone(this.$x, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void CompoundAssignmentToAnArrayElementWithUserDefinedBinaryOperatorsAssigningTheResultWorks() {
			AssertCorrect(@"
class C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1[] x = null;
	C1 y = null, z = null;
	int i = 0;
	// BEGIN
	z = x[0] +=  y;
	z = x[0] -=  y;
	z = x[0] *=  y;
	z = x[0] /=  y;
	z = x[0] %=  y;
	z = x[0] &=  y;
	z = x[0] |=  y;
	z = x[0] ^=  y;
	z = x[0] <<= i;
	z = x[0] >>= i;
	// END
}",
@"	$z = $x[0] = {sm_C1}.$op_Addition($x[0], $y);
	$z = $x[0] = {sm_C1}.$op_Subtraction($x[0], $y);
	$z = $x[0] = {sm_C1}.$op_Multiply($x[0], $y);
	$z = $x[0] = {sm_C1}.$op_Division($x[0], $y);
	$z = $x[0] = {sm_C1}.$op_Modulus($x[0], $y);
	$z = $x[0] = {sm_C1}.$op_BitwiseAnd($x[0], $y);
	$z = $x[0] = {sm_C1}.$op_BitwiseOr($x[0], $y);
	$z = $x[0] = {sm_C1}.$op_ExclusiveOr($x[0], $y);
	$z = $x[0] = {sm_C1}.$op_LeftShift($x[0], $i);
	$z = $x[0] = {sm_C1}.$op_RightShift($x[0], $i);
");
		}

		[Test]
		public void CompoundAssignmentToAnArrayElementWithUserDefinedBinaryOperatorsAssigningTheResultWorksStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1[] x = null;
	C1 y = default(C1), z = default(C1);
	int i = 0;
	// BEGIN
	z = x[0] +=  y;
	z = x[0] -=  y;
	z = x[0] *=  y;
	z = x[0] /=  y;
	z = x[0] %=  y;
	z = x[0] &=  y;
	z = x[0] |=  y;
	z = x[0] ^=  y;
	z = x[0] <<= i;
	z = x[0] >>= i;
	// END
}",
@"	$x[0] = {sm_C1}.$op_Addition($x[0], $Clone($y, {to_C1}));
	$z = $Clone($x[0], {to_C1});
	$x[0] = {sm_C1}.$op_Subtraction($x[0], $Clone($y, {to_C1}));
	$z = $Clone($x[0], {to_C1});
	$x[0] = {sm_C1}.$op_Multiply($x[0], $Clone($y, {to_C1}));
	$z = $Clone($x[0], {to_C1});
	$x[0] = {sm_C1}.$op_Division($x[0], $Clone($y, {to_C1}));
	$z = $Clone($x[0], {to_C1});
	$x[0] = {sm_C1}.$op_Modulus($x[0], $Clone($y, {to_C1}));
	$z = $Clone($x[0], {to_C1});
	$x[0] = {sm_C1}.$op_BitwiseAnd($x[0], $Clone($y, {to_C1}));
	$z = $Clone($x[0], {to_C1});
	$x[0] = {sm_C1}.$op_BitwiseOr($x[0], $Clone($y, {to_C1}));
	$z = $Clone($x[0], {to_C1});
	$x[0] = {sm_C1}.$op_ExclusiveOr($x[0], $Clone($y, {to_C1}));
	$z = $Clone($x[0], {to_C1});
	$x[0] = {sm_C1}.$op_LeftShift($x[0], $Clone($i, {to_Int32}));
	$z = $Clone($x[0], {to_C1});
	$x[0] = {sm_C1}.$op_RightShift($x[0], $Clone($i, {to_Int32}));
	$z = $Clone($x[0], {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void CompoundAssignmentToAnIndexerWithUserDefinedBinaryOperatorsAssigningTheResultWorks() {
			AssertCorrect(@"
class C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
C1 this[int i] { get { return null; } set {} }
void M() {
	C1 y = null, z = null;
	int i = 0;
	// BEGIN
	z = this[0] +=  y;
	z = this[0] -=  y;
	z = this[0] *=  y;
	z = this[0] /=  y;
	z = this[0] %=  y;
	z = this[0] &=  y;
	z = this[0] |=  y;
	z = this[0] ^=  y;
	z = this[0] <<= i;
	z = this[0] >>= i;
	// END
}",
@"	var $tmp1 = {sm_C1}.$op_Addition(this.get_$Item(0), $y);
	this.set_$Item(0, $tmp1);
	$z = $tmp1;
	var $tmp2 = {sm_C1}.$op_Subtraction(this.get_$Item(0), $y);
	this.set_$Item(0, $tmp2);
	$z = $tmp2;
	var $tmp3 = {sm_C1}.$op_Multiply(this.get_$Item(0), $y);
	this.set_$Item(0, $tmp3);
	$z = $tmp3;
	var $tmp4 = {sm_C1}.$op_Division(this.get_$Item(0), $y);
	this.set_$Item(0, $tmp4);
	$z = $tmp4;
	var $tmp5 = {sm_C1}.$op_Modulus(this.get_$Item(0), $y);
	this.set_$Item(0, $tmp5);
	$z = $tmp5;
	var $tmp6 = {sm_C1}.$op_BitwiseAnd(this.get_$Item(0), $y);
	this.set_$Item(0, $tmp6);
	$z = $tmp6;
	var $tmp7 = {sm_C1}.$op_BitwiseOr(this.get_$Item(0), $y);
	this.set_$Item(0, $tmp7);
	$z = $tmp7;
	var $tmp8 = {sm_C1}.$op_ExclusiveOr(this.get_$Item(0), $y);
	this.set_$Item(0, $tmp8);
	$z = $tmp8;
	var $tmp9 = {sm_C1}.$op_LeftShift(this.get_$Item(0), $i);
	this.set_$Item(0, $tmp9);
	$z = $tmp9;
	var $tmp10 = {sm_C1}.$op_RightShift(this.get_$Item(0), $i);
	this.set_$Item(0, $tmp10);
	$z = $tmp10;
");
		}

		[Test]
		public void CompoundAssignmentToAnIndexerWithUserDefinedBinaryOperatorsAssigningTheResultWorksStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
C1 this[int i] { get { return default(C1); } set {} }
void M() {
	C1 y = default(C1), z = default(C1);
	int i = 0;
	// BEGIN
	z = this[0] +=  y;
	z = this[0] -=  y;
	z = this[0] *=  y;
	z = this[0] /=  y;
	z = this[0] %=  y;
	z = this[0] &=  y;
	z = this[0] |=  y;
	z = this[0] ^=  y;
	z = this[0] <<= i;
	z = this[0] >>= i;
	// END
}",
@"	var $tmp1 = {sm_C1}.$op_Addition(this.get_$Item(0), $Clone($y, {to_C1}));
	this.set_$Item(0, $Clone($tmp1, {to_C1}));
	$z = $Clone($tmp1, {to_C1});
	var $tmp2 = {sm_C1}.$op_Subtraction(this.get_$Item(0), $Clone($y, {to_C1}));
	this.set_$Item(0, $Clone($tmp2, {to_C1}));
	$z = $Clone($tmp2, {to_C1});
	var $tmp3 = {sm_C1}.$op_Multiply(this.get_$Item(0), $Clone($y, {to_C1}));
	this.set_$Item(0, $Clone($tmp3, {to_C1}));
	$z = $Clone($tmp3, {to_C1});
	var $tmp4 = {sm_C1}.$op_Division(this.get_$Item(0), $Clone($y, {to_C1}));
	this.set_$Item(0, $Clone($tmp4, {to_C1}));
	$z = $Clone($tmp4, {to_C1});
	var $tmp5 = {sm_C1}.$op_Modulus(this.get_$Item(0), $Clone($y, {to_C1}));
	this.set_$Item(0, $Clone($tmp5, {to_C1}));
	$z = $Clone($tmp5, {to_C1});
	var $tmp6 = {sm_C1}.$op_BitwiseAnd(this.get_$Item(0), $Clone($y, {to_C1}));
	this.set_$Item(0, $Clone($tmp6, {to_C1}));
	$z = $Clone($tmp6, {to_C1});
	var $tmp7 = {sm_C1}.$op_BitwiseOr(this.get_$Item(0), $Clone($y, {to_C1}));
	this.set_$Item(0, $Clone($tmp7, {to_C1}));
	$z = $Clone($tmp7, {to_C1});
	var $tmp8 = {sm_C1}.$op_ExclusiveOr(this.get_$Item(0), $Clone($y, {to_C1}));
	this.set_$Item(0, $Clone($tmp8, {to_C1}));
	$z = $Clone($tmp8, {to_C1});
	var $tmp9 = {sm_C1}.$op_LeftShift(this.get_$Item(0), $Clone($i, {to_Int32}));
	this.set_$Item(0, $Clone($tmp9, {to_C1}));
	$z = $Clone($tmp9, {to_C1});
	var $tmp10 = {sm_C1}.$op_RightShift(this.get_$Item(0), $Clone($i, {to_Int32}));
	this.set_$Item(0, $Clone($tmp10, {to_C1}));
	$z = $Clone($tmp10, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void CompoundAssignmentWithLiftedUserDefinedBinaryOperatorsWork() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1? x = null, y = null;
	int i = 0;
	// BEGIN
	x +=  y;
	x -=  y;
	x *=  y;
	x /=  y;
	x %=  y;
	x &=  y;
	x |=  y;
	x ^=  y;
	x <<= i;
	x >>= i;
	// END
}",
@"	$x = $Lift({sm_C1}.$op_Addition($x, $y), Regular);
	$x = $Lift({sm_C1}.$op_Subtraction($x, $y), Regular);
	$x = $Lift({sm_C1}.$op_Multiply($x, $y), Regular);
	$x = $Lift({sm_C1}.$op_Division($x, $y), Regular);
	$x = $Lift({sm_C1}.$op_Modulus($x, $y), Regular);
	$x = $Lift({sm_C1}.$op_BitwiseAnd($x, $y), Regular);
	$x = $Lift({sm_C1}.$op_BitwiseOr($x, $y), Regular);
	$x = $Lift({sm_C1}.$op_ExclusiveOr($x, $y), Regular);
	$x = $Lift({sm_C1}.$op_LeftShift($x, $i), Regular);
	$x = $Lift({sm_C1}.$op_RightShift($x, $i), Regular);
");
		}

		[Test]
		public void CompoundAssignmentWithLiftedUserDefinedBinaryOperatorsWorkStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1? x = null, y = null;
	int i = 0;
	// BEGIN
	x +=  y;
	x -=  y;
	x *=  y;
	x /=  y;
	x %=  y;
	x &=  y;
	x |=  y;
	x ^=  y;
	x <<= i;
	x >>= i;
	// END
}",
@"	$x = $Lift({sm_C1}.$op_Addition($x, $Clone($y, {to_C1})), Regular);
	$x = $Lift({sm_C1}.$op_Subtraction($x, $Clone($y, {to_C1})), Regular);
	$x = $Lift({sm_C1}.$op_Multiply($x, $Clone($y, {to_C1})), Regular);
	$x = $Lift({sm_C1}.$op_Division($x, $Clone($y, {to_C1})), Regular);
	$x = $Lift({sm_C1}.$op_Modulus($x, $Clone($y, {to_C1})), Regular);
	$x = $Lift({sm_C1}.$op_BitwiseAnd($x, $Clone($y, {to_C1})), Regular);
	$x = $Lift({sm_C1}.$op_BitwiseOr($x, $Clone($y, {to_C1})), Regular);
	$x = $Lift({sm_C1}.$op_ExclusiveOr($x, $Clone($y, {to_C1})), Regular);
	$x = $Lift({sm_C1}.$op_LeftShift($x, $Clone($i, {to_Int32})), Regular);
	$x = $Lift({sm_C1}.$op_RightShift($x, $Clone($i, {to_Int32})), Regular);
", mutableValueTypes: true);
		}

		[Test]
		public void CompoundAssignmentWithLiftedUserDefinedBinaryOperatorsAssigningTheResultWork() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1? x = null, y = null, z = null;
	int i = 0;
	// BEGIN
	z = x +=  y;
	z = x -=  y;
	z = x *=  y;
	z = x /=  y;
	z = x %=  y;
	z = x &=  y;
	z = x |=  y;
	z = x ^=  y;
	z = x <<= i;
	z = x >>= i;
	// END
}",
@"	$z = $x = $Lift({sm_C1}.$op_Addition($x, $y), Regular);
	$z = $x = $Lift({sm_C1}.$op_Subtraction($x, $y), Regular);
	$z = $x = $Lift({sm_C1}.$op_Multiply($x, $y), Regular);
	$z = $x = $Lift({sm_C1}.$op_Division($x, $y), Regular);
	$z = $x = $Lift({sm_C1}.$op_Modulus($x, $y), Regular);
	$z = $x = $Lift({sm_C1}.$op_BitwiseAnd($x, $y), Regular);
	$z = $x = $Lift({sm_C1}.$op_BitwiseOr($x, $y), Regular);
	$z = $x = $Lift({sm_C1}.$op_ExclusiveOr($x, $y), Regular);
	$z = $x = $Lift({sm_C1}.$op_LeftShift($x, $i), Regular);
	$z = $x = $Lift({sm_C1}.$op_RightShift($x, $i), Regular);
");
		}

		[Test]
		public void CompoundAssignmentWithLiftedUserDefinedBinaryOperatorsAssigningTheResultWorkStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator-(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator*(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator/(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator%(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator&(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator|(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator^(C1 c1, C1 c2) { return default(C1); }
	public static C1 operator<<(C1 c1, int i) { return default(C1); }
	public static C1 operator>>(C1 c1, int i) { return default(C1); }
}
void M() {
	C1? x = null, y = null, z = null;
	int i = 0;
	// BEGIN
	z = x +=  y;
	z = x -=  y;
	z = x *=  y;
	z = x /=  y;
	z = x %=  y;
	z = x &=  y;
	z = x |=  y;
	z = x ^=  y;
	z = x <<= i;
	z = x >>= i;
	// END
}",
@"	$x = $Lift({sm_C1}.$op_Addition($x, $Clone($y, {to_C1})), Regular);
	$z = $Clone($x, {to_C1});
	$x = $Lift({sm_C1}.$op_Subtraction($x, $Clone($y, {to_C1})), Regular);
	$z = $Clone($x, {to_C1});
	$x = $Lift({sm_C1}.$op_Multiply($x, $Clone($y, {to_C1})), Regular);
	$z = $Clone($x, {to_C1});
	$x = $Lift({sm_C1}.$op_Division($x, $Clone($y, {to_C1})), Regular);
	$z = $Clone($x, {to_C1});
	$x = $Lift({sm_C1}.$op_Modulus($x, $Clone($y, {to_C1})), Regular);
	$z = $Clone($x, {to_C1});
	$x = $Lift({sm_C1}.$op_BitwiseAnd($x, $Clone($y, {to_C1})), Regular);
	$z = $Clone($x, {to_C1});
	$x = $Lift({sm_C1}.$op_BitwiseOr($x, $Clone($y, {to_C1})), Regular);
	$z = $Clone($x, {to_C1});
	$x = $Lift({sm_C1}.$op_ExclusiveOr($x, $Clone($y, {to_C1})), Regular);
	$z = $Clone($x, {to_C1});
	$x = $Lift({sm_C1}.$op_LeftShift($x, $Clone($i, {to_Int32})), Regular);
	$z = $Clone($x, {to_C1});
	$x = $Lift({sm_C1}.$op_RightShift($x, $Clone($i, {to_Int32})), Regular);
	$z = $Clone($x, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void UnaryNonAssigningOperatorsWork() {
			AssertCorrect(@"
class C1 {
	public static C1 operator+(C1 c) { return default(C1); }
	public static C1 operator-(C1 c) { return default(C1); }
	public static C1 operator!(C1 c) { return default(C1); }
	public static C1 operator~(C1 c) { return default(C1); }
}
void M() {
	C1 x = null, y;
	// BEGIN
	y = +x;
	y = -x;
	y = !x;
	y = ~x;
	// END
}",
@"	$y = {sm_C1}.$op_UnaryPlus($x);
	$y = {sm_C1}.$op_UnaryNegation($x);
	$y = {sm_C1}.$op_LogicalNot($x);
	$y = {sm_C1}.$op_OnesComplement($x);
");
		}

		[Test]
		public void UnaryNonAssigningOperatorsWorkStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c) { return default(C1); }
	public static C1 operator-(C1 c) { return default(C1); }
	public static C1 operator!(C1 c) { return default(C1); }
	public static C1 operator~(C1 c) { return default(C1); }
}
void M() {
	C1 x = default(C1), y;
	// BEGIN
	y = +x;
	y = -x;
	y = !x;
	y = ~x;
	// END
}",
@"	$y = {sm_C1}.$op_UnaryPlus($Clone($x, {to_C1}));
	$y = {sm_C1}.$op_UnaryNegation($Clone($x, {to_C1}));
	$y = {sm_C1}.$op_LogicalNot($Clone($x, {to_C1}));
	$y = {sm_C1}.$op_OnesComplement($Clone($x, {to_C1}));
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedUnaryNonAssigningOperatorsWork() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c) { return default(C1); }
	public static C1 operator-(C1 c) { return default(C1); }
	public static C1 operator!(C1 c) { return default(C1); }
	public static C1 operator~(C1 c) { return default(C1); }
}
void M() {
	C1? x = null, y;
	// BEGIN
	y = +x;
	y = -x;
	y = !x;
	y = ~x;
	// END
}",
@"	$y = $Lift({sm_C1}.$op_UnaryPlus($x), Regular);
	$y = $Lift({sm_C1}.$op_UnaryNegation($x), Regular);
	$y = $Lift({sm_C1}.$op_LogicalNot($x), Regular);
	$y = $Lift({sm_C1}.$op_OnesComplement($x), Regular);
");
		}

		[Test]
		public void LiftedUnaryNonAssigningOperatorsWorkStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator+(C1 c) { return default(C1); }
	public static C1 operator-(C1 c) { return default(C1); }
	public static C1 operator!(C1 c) { return default(C1); }
	public static C1 operator~(C1 c) { return default(C1); }
}
void M() {
	C1? x = null, y;
	// BEGIN
	y = +x;
	y = -x;
	y = !x;
	y = ~x;
	// END
}",
@"	$y = $Lift({sm_C1}.$op_UnaryPlus($Clone($x, {to_C1})), Regular);
	$y = $Lift({sm_C1}.$op_UnaryNegation($Clone($x, {to_C1})), Regular);
	$y = $Lift({sm_C1}.$op_LogicalNot($Clone($x, {to_C1})), Regular);
	$y = $Lift({sm_C1}.$op_OnesComplement($Clone($x, {to_C1})), Regular);
", mutableValueTypes: true);
		}

		[Test, Ignore("Not yet supported")]
		public void OperatorsTrueAndFalseWork() {
			AssertCorrect(@"
class C1 {
	public static C1 operator &(C1 c1, C1 c2) { return null; }
	public static C1 operator |(C1 c1, C1 c2) { return null; }
	public static bool operator false(C1 c) { return false; }
	public static bool operator true(C1 c) { return false; }
}
void M() {
	C1 c1 = null, c2 = null, c3;
	// BEGIN
	c3 = c1 && c2;
	c3 = c1 || c2;
	// END
	}
}",
@"	// TODO: Not supported
");
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnVariablesWhenNotAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1 c = null;
	// BEGIN
	c++;
	++c;
	c--;
	--c;
	// END
}",
@"	$c = {sm_C1}.$op_Increment($c);
	$c = {sm_C1}.$op_Increment($c);
	$c = {sm_C1}.$op_Decrement($c);
	$c = {sm_C1}.$op_Decrement($c);
");
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnVariablesWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1 c = default(C1);
	// BEGIN
	c++;
	++c;
	c--;
	--c;
	// END
}",
@"	$c = {sm_C1}.$op_Increment($c);
	$c = {sm_C1}.$op_Increment($c);
	$c = {sm_C1}.$op_Decrement($c);
	$c = {sm_C1}.$op_Decrement($c);
", mutableValueTypes: true);
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnThisWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }

void M() {
	C1 c = default(C1);
	// BEGIN
	this++;
	++this;
	this--;
	--this;
	// END
}
}",
@"	$ShallowCopy({sm_C1}.$op_Increment(this), this);
	$ShallowCopy({sm_C1}.$op_Increment(this), this);
	$ShallowCopy({sm_C1}.$op_Decrement(this), this);
	$ShallowCopy({sm_C1}.$op_Decrement(this), this);
", addSkeleton: false, mutableValueTypes: true);
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnVariablesWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1 c = null, c1, c2;
	// BEGIN
	c1 = ++c;
	c2 = --c;
	// END
}",
@"	$c1 = $c = {sm_C1}.$op_Increment($c);
	$c2 = $c = {sm_C1}.$op_Decrement($c);
");
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnVariablesWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1 c = default(C1), c1, c2;
	// BEGIN
	c1 = ++c;
	c2 = --c;
	// END
}",
@"	$c = {sm_C1}.$op_Increment($c);
	$c1 = $Clone($c, {to_C1});
	$c = {sm_C1}.$op_Decrement($c);
	$c2 = $Clone($c, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnVariablesWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1 c = null, c1, c2;
	// BEGIN
	c1 = c++;
	c2 = c--;
	// END
}",
@"	var $tmp1 = $c;
	$c = {sm_C1}.$op_Increment($tmp1);
	$c1 = $tmp1;
	var $tmp2 = $c;
	$c = {sm_C1}.$op_Decrement($tmp2);
	$c2 = $tmp2;
");
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnVariablesWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1 c = default(C1), c1, c2;
	// BEGIN
	c1 = c++;
	c2 = c--;
	// END
}",
@"	var $tmp1 = $c;
	$c = {sm_C1}.$op_Increment($Clone($tmp1, {to_C1}));
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = $c;
	$c = {sm_C1}.$op_Decrement($Clone($tmp2, {to_C1}));
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnThisWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }

void M() {
	C1 c = default(C1);
	// BEGIN
	c = this++;
	c = this--;
	// END
}
}",
@"	var $tmp1 = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_Increment($Clone($tmp1, {to_C1})), this);
	$c = $Clone($tmp1, {to_C1});
	var $tmp2 = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_Decrement($Clone($tmp2, {to_C1})), this);
	$c = $Clone($tmp2, {to_C1});
", addSkeleton: false, mutableValueTypes: true);
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnFieldsWhenNotAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
C1 c;
void M() {
	// BEGIN
	c++;
	++c;
	c--;
	--c;
	// END
}",
@"	this.$c = {sm_C1}.$op_Increment(this.$c);
	this.$c = {sm_C1}.$op_Increment(this.$c);
	this.$c = {sm_C1}.$op_Decrement(this.$c);
	this.$c = {sm_C1}.$op_Decrement(this.$c);
");
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnFieldsWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
C1 c;
void M() {
	// BEGIN
	c++;
	++c;
	c--;
	--c;
	// END
}",
@"	this.$c = {sm_C1}.$op_Increment(this.$c);
	this.$c = {sm_C1}.$op_Increment(this.$c);
	this.$c = {sm_C1}.$op_Decrement(this.$c);
	this.$c = {sm_C1}.$op_Decrement(this.$c);
", mutableValueTypes: true);
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnFieldsWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
C1 c;
void M() {
	C1 c1, c2;
	// BEGIN
	c1 = ++c;
	c2 = --c;
	// END
}",
@"	$c1 = this.$c = {sm_C1}.$op_Increment(this.$c);
	$c2 = this.$c = {sm_C1}.$op_Decrement(this.$c);
");
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnFieldsWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1 c;
void M() {
	C1 c1, c2;
	// BEGIN
	c1 = ++c;
	c2 = --c;
	// END
}",
@"	this.$c = {sm_C1}.$op_Increment(this.$c);
	$c1 = $Clone(this.$c, {to_C1});
	this.$c = {sm_C1}.$op_Decrement(this.$c);
	$c2 = $Clone(this.$c, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnThisWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }

void M() {
	C1 c = default(C1);
	// BEGIN
	c = ++this;
	c = --this;
	// END
}
}",
@"	$ShallowCopy({sm_C1}.$op_Increment(this), this);
	$c = $Clone(this, {to_C1});
	$ShallowCopy({sm_C1}.$op_Decrement(this), this);
	$c = $Clone(this, {to_C1});
", addSkeleton: false, mutableValueTypes: true);
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnFieldsWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
C1 c;
void M() {
	C1 c1, c2;
	// BEGIN
	c1 = c++;
	c2 = c--;
	// END
}",
@"	var $tmp1 = this.$c;
	this.$c = {sm_C1}.$op_Increment($tmp1);
	$c1 = $tmp1;
	var $tmp2 = this.$c;
	this.$c = {sm_C1}.$op_Decrement($tmp2);
	$c2 = $tmp2;
");
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnFieldsWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1 c;
void M() {
	C1 c1, c2;
	// BEGIN
	c1 = c++;
	c2 = c--;
	// END
}",
@"	var $tmp1 = this.$c;
	this.$c = {sm_C1}.$op_Increment($Clone($tmp1, {to_C1}));
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = this.$c;
	this.$c = {sm_C1}.$op_Decrement($Clone($tmp2, {to_C1}));
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnArraysWhenNotAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1[] c = null;
	// BEGIN
	c[0]++;
	++c[0];
	c[0]--;
	--c[0];
	// END
}",
@"	$c[0] = {sm_C1}.$op_Increment($c[0]);
	$c[0] = {sm_C1}.$op_Increment($c[0]);
	$c[0] = {sm_C1}.$op_Decrement($c[0]);
	$c[0] = {sm_C1}.$op_Decrement($c[0]);
");
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnArraysWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1[] c = null;
	// BEGIN
	c[0]++;
	++c[0];
	c[0]--;
	--c[0];
	// END
}",
@"	$c[0] = {sm_C1}.$op_Increment($c[0]);
	$c[0] = {sm_C1}.$op_Increment($c[0]);
	$c[0] = {sm_C1}.$op_Decrement($c[0]);
	$c[0] = {sm_C1}.$op_Decrement($c[0]);
", mutableValueTypes: true);
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnArraysWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1[] c = null;
	C1 c1, c2;
	// BEGIN
	c1 = ++c[0];
	c2 = --c[0];
	// END
}",
@"	$c1 = $c[0] = {sm_C1}.$op_Increment($c[0]);
	$c2 = $c[0] = {sm_C1}.$op_Decrement($c[0]);
");
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnArraysWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1[] c = null;
	C1 c1, c2;
	// BEGIN
	c1 = ++c[0];
	c2 = --c[0];
	// END
}",
@"	$c[0] = {sm_C1}.$op_Increment($c[0]);
	$c1 = $Clone($c[0], {to_C1});
	$c[0] = {sm_C1}.$op_Decrement($c[0]);
	$c2 = $Clone($c[0], {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnArraysWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1[] c = null;
	C1 c1, c2;
	// BEGIN
	c1 = c[0]++;
	c2 = c[0]--;
	// END
}",
@"	var $tmp1 = $c[0];
	$c[0] = {sm_C1}.$op_Increment($tmp1);
	$c1 = $tmp1;
	var $tmp2 = $c[0];
	$c[0] = {sm_C1}.$op_Decrement($tmp2);
	$c2 = $tmp2;
");
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnArraysWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1[] c = null;
	C1 c1, c2;
	// BEGIN
	c1 = c[0]++;
	c2 = c[0]--;
	// END
}",
@"	var $tmp1 = $c[0];
	$c[0] = {sm_C1}.$op_Increment($Clone($tmp1, {to_C1}));
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = $c[0];
	$c[0] = {sm_C1}.$op_Decrement($Clone($tmp2, {to_C1}));
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnMultidimArraysWhenNotAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1[,] c = null;
	// BEGIN
	c[0,1]++;
	++c[0,1];
	c[0,1]--;
	--c[0,1];
	// END
}",
@"	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Increment($MultidimArrayGet($c, 0, 1)));
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Increment($MultidimArrayGet($c, 0, 1)));
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Decrement($MultidimArrayGet($c, 0, 1)));
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Decrement($MultidimArrayGet($c, 0, 1)));
");
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnMultidimArraysWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1[,] c = null;
	// BEGIN
	c[0,1]++;
	++c[0,1];
	c[0,1]--;
	--c[0,1];
	// END
}",
@"	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Increment($MultidimArrayGet($c, 0, 1)));
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Increment($MultidimArrayGet($c, 0, 1)));
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Decrement($MultidimArrayGet($c, 0, 1)));
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Decrement($MultidimArrayGet($c, 0, 1)));
", mutableValueTypes: true);
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnMultidimArraysWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1[,] c = null;
	C1 c1, c2;
	// BEGIN
	c1 = ++c[0,1];
	c2 = --c[0,1];
	// END
}",
@"	var $tmp1 = {sm_C1}.$op_Increment($MultidimArrayGet($c, 0, 1));
	$MultidimArraySet($c, 0, 1, $tmp1);
	$c1 = $tmp1;
	var $tmp2 = {sm_C1}.$op_Decrement($MultidimArrayGet($c, 0, 1));
	$MultidimArraySet($c, 0, 1, $tmp2);
	$c2 = $tmp2;
");
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnMultidimArraysWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1[,] c = null;
	C1 c1, c2;
	// BEGIN
	c1 = ++c[0,1];
	c2 = --c[0,1];
	// END
}",
@"	var $tmp1 = {sm_C1}.$op_Increment($MultidimArrayGet($c, 0, 1));
	$MultidimArraySet($c, 0, 1, $Clone($tmp1, {to_C1}));
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = {sm_C1}.$op_Decrement($MultidimArrayGet($c, 0, 1));
	$MultidimArraySet($c, 0, 1, $Clone($tmp2, {to_C1}));
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnMultidimArraysWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
void M() {
	C1[,] c = null;
	C1 c1, c2;
	// BEGIN
	c1 = c[0,1]++;
	c2 = c[0,1]--;
	// END
}",
@"	var $tmp1 = $MultidimArrayGet($c, 0, 1);
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Increment($tmp1));
	$c1 = $tmp1;
	var $tmp2 = $MultidimArrayGet($c, 0, 1);
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Decrement($tmp2));
	$c2 = $tmp2;
");
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnMultidimArraysWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1[] c = null;
	C1 c1, c2;
	// BEGIN
	c1 = c[0,1]++;
	c2 = c[0,1]--;
	// END
}",
@"	var $tmp1 = $MultidimArrayGet($c, 0, 1);
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Increment($Clone($tmp1, {to_C1})));
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = $MultidimArrayGet($c, 0, 1);
	$MultidimArraySet($c, 0, 1, {sm_C1}.$op_Decrement($Clone($tmp2, {to_C1})));
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnPropertiesWhenNotAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
C1 P { get; set; }
void M() {
	// BEGIN
	P++;
	++P;
	P--;
	--P;
	// END
}",
@"	this.set_$P({sm_C1}.$op_Increment(this.get_$P()));
	this.set_$P({sm_C1}.$op_Increment(this.get_$P()));
	this.set_$P({sm_C1}.$op_Decrement(this.get_$P()));
	this.set_$P({sm_C1}.$op_Decrement(this.get_$P()));
");
		}

		[Test]
		public void IncrementAndDecrementOperatorsWorkOnPropertiesWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
C1 P { get; set; }
void M() {
	// BEGIN
	P++;
	++P;
	P--;
	--P;
	// END
}",
@"	this.set_$P({sm_C1}.$op_Increment(this.get_$P()));
	this.set_$P({sm_C1}.$op_Increment(this.get_$P()));
	this.set_$P({sm_C1}.$op_Decrement(this.get_$P()));
	this.set_$P({sm_C1}.$op_Decrement(this.get_$P()));
", mutableValueTypes: true);
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnPropertiesWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
C1 P { get; set; }
void M() {
	C1 c1, c2;
	// BEGIN
	c1 = ++P;
	c2 = --P;
	// END
}",
@"	var $tmp1 = {sm_C1}.$op_Increment(this.get_$P());
	this.set_$P($tmp1);
	$c1 = $tmp1;
	var $tmp2 = {sm_C1}.$op_Decrement(this.get_$P());
	this.set_$P($tmp2);
	$c2 = $tmp2;
");
		}

		[Test]
		public void PreIncrementAndDecrementOperatorsWorkOnPropertiesWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1 P { get; set; }
void M() {
	C1 c1, c2;
	// BEGIN
	c1 = ++P;
	c2 = --P;
	// END
}",
@"	var $tmp1 = {sm_C1}.$op_Increment(this.get_$P());
	this.set_$P($Clone($tmp1, {to_C1}));
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = {sm_C1}.$op_Decrement(this.get_$P());
	this.set_$P($Clone($tmp2, {to_C1}));
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnPropertiesWhenAssigningTheResult() {
			AssertCorrect(@"
class C1 {
	public static C1 operator++(C1 c) { return null; }
	public static C1 operator--(C1 c) { return null; }
}
C1 P { get; set; }
void M() {
	C1 c1, c2;
	// BEGIN
	c1 = P++;
	c2 = P--;
	// END
}",
@"	var $tmp1 = this.get_$P();
	this.set_$P({sm_C1}.$op_Increment($tmp1));
	$c1 = $tmp1;
	var $tmp2 = this.get_$P();
	this.set_$P({sm_C1}.$op_Decrement($tmp2));
	$c2 = $tmp2;
");
		}

		[Test]
		public void PostIncrementAndDecrementOperatorsWorkOnPropertiesWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1 P { get; set; }
void M() {
	C1 c1, c2;
	// BEGIN
	c1 = P++;
	c2 = P--;
	// END
}",
@"	var $tmp1 = this.get_$P();
	this.set_$P($Clone({sm_C1}.$op_Increment($Clone($tmp1, {to_C1})), {to_C1}));
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = this.get_$P();
	this.set_$P($Clone({sm_C1}.$op_Decrement($Clone($tmp2, {to_C1})), {to_C1}));
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedIncrementAndDecrementOperatorsWorkOnVariablesWhenNotAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1? c = null;
	// BEGIN
	c++;
	++c;
	c--;
	--c;
	// END
}",
@"	$c = $Lift({sm_C1}.$op_Increment($c), Regular);
	$c = $Lift({sm_C1}.$op_Increment($c), Regular);
	$c = $Lift({sm_C1}.$op_Decrement($c), Regular);
	$c = $Lift({sm_C1}.$op_Decrement($c), Regular);
");
		}

		[Test]
		public void LiftedIncrementAndDecrementOperatorsWorkOnVariablesWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1? c = null;
	// BEGIN
	c++;
	++c;
	c--;
	--c;
	// END
}",
@"	$c = $Lift({sm_C1}.$op_Increment($c), Regular);
	$c = $Lift({sm_C1}.$op_Increment($c), Regular);
	$c = $Lift({sm_C1}.$op_Decrement($c), Regular);
	$c = $Lift({sm_C1}.$op_Decrement($c), Regular);
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedPreIncrementAndDecrementOperatorsWorkOnVariablesWhenAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1? c = null, c1, c2;
	// BEGIN
	c1 = ++c;
	c2 = --c;
	// END
}",
@"	$c1 = $c = $Lift({sm_C1}.$op_Increment($c), Regular);
	$c2 = $c = $Lift({sm_C1}.$op_Decrement($c), Regular);
");
		}

		[Test]
		public void LiftedPreIncrementAndDecrementOperatorsWorkOnVariablesWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1? c = null, c1, c2;
	// BEGIN
	c1 = ++c;
	c2 = --c;
	// END
}",
@"	$c = $Lift({sm_C1}.$op_Increment($c), Regular);
	$c1 = $Clone($c, {to_C1});
	$c = $Lift({sm_C1}.$op_Decrement($c), Regular);
	$c2 = $Clone($c, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedPostIncrementAndDecrementOperatorsWorkOnVariablesWhenAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1? c = null, c1, c2;
	// BEGIN
	c1 = c++;
	c2 = c--;
	// END
}",
@"	var $tmp1 = $c;
	$c = $Lift({sm_C1}.$op_Increment($tmp1), Regular);
	$c1 = $tmp1;
	var $tmp2 = $c;
	$c = $Lift({sm_C1}.$op_Decrement($tmp2), Regular);
	$c2 = $tmp2;
");
		}

		[Test]
		public void LiftedPostIncrementAndDecrementOperatorsWorkOnVariablesWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1? c = null, c1, c2;
	// BEGIN
	c1 = c++;
	c2 = c--;
	// END
}",
@"	var $tmp1 = $c;
	$c = $Lift({sm_C1}.$op_Increment($Clone($tmp1, {to_C1})), Regular);
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = $c;
	$c = $Lift({sm_C1}.$op_Decrement($Clone($tmp2, {to_C1})), Regular);
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedIncrementAndDecrementOperatorsWorkOnFieldsWhenNotAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? c;
void M() {
	// BEGIN
	c++;
	++c;
	c--;
	--c;
	// END
}",
@"	this.$c = $Lift({sm_C1}.$op_Increment(this.$c), Regular);
	this.$c = $Lift({sm_C1}.$op_Increment(this.$c), Regular);
	this.$c = $Lift({sm_C1}.$op_Decrement(this.$c), Regular);
	this.$c = $Lift({sm_C1}.$op_Decrement(this.$c), Regular);
");
		}

		[Test]
		public void LiftedIncrementAndDecrementOperatorsWorkOnFieldsWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? c = null;
void M() {
	// BEGIN
	c++;
	++c;
	c--;
	--c;
	// END
}",
@"	this.$c = $Lift({sm_C1}.$op_Increment(this.$c), Regular);
	this.$c = $Lift({sm_C1}.$op_Increment(this.$c), Regular);
	this.$c = $Lift({sm_C1}.$op_Decrement(this.$c), Regular);
	this.$c = $Lift({sm_C1}.$op_Decrement(this.$c), Regular);
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedPreIncrementAndDecrementOperatorsWorkOnFieldsWhenAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? c = null;
void M() {
	C1? c1, c2;
	// BEGIN
	c1 = ++c;
	c2 = --c;
	// END
}",
@"	$c1 = this.$c = $Lift({sm_C1}.$op_Increment(this.$c), Regular);
	$c2 = this.$c = $Lift({sm_C1}.$op_Decrement(this.$c), Regular);
");
		}

		[Test]
		public void LiftedPreIncrementAndDecrementOperatorsWorkOnFieldsWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? c = null;
void M() {
	C1? c1, c2;
	// BEGIN
	c1 = ++c;
	c2 = --c;
	// END
}",
@"	this.$c = $Lift({sm_C1}.$op_Increment(this.$c), Regular);
	$c1 = $Clone(this.$c, {to_C1});
	this.$c = $Lift({sm_C1}.$op_Decrement(this.$c), Regular);
	$c2 = $Clone(this.$c, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedPostIncrementAndDecrementOperatorsWorkOnFieldsWhenAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? c = null;
void M() {
	C1? c1, c2;
	// BEGIN
	c1 = c++;
	c2 = c--;
	// END
}",
@"	var $tmp1 = this.$c;
	this.$c = $Lift({sm_C1}.$op_Increment($tmp1), Regular);
	$c1 = $tmp1;
	var $tmp2 = this.$c;
	this.$c = $Lift({sm_C1}.$op_Decrement($tmp2), Regular);
	$c2 = $tmp2;
");
		}

		[Test]
		public void LiftedPostIncrementAndDecrementOperatorsWorkOnFieldsWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? c = null;
void M() {
	C1? c1, c2;
	// BEGIN
	c1 = c++;
	c2 = c--;
	// END
}",
@"	var $tmp1 = this.$c;
	this.$c = $Lift({sm_C1}.$op_Increment($Clone($tmp1, {to_C1})), Regular);
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = this.$c;
	this.$c = $Lift({sm_C1}.$op_Decrement($Clone($tmp2, {to_C1})), Regular);
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedIncrementAndDecrementOperatorsWorkOnArraysWhenNotAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1?[] c = null;
	// BEGIN
	c[0]++;
	++c[0];
	c[0]--;
	--c[0];
	// END
}",
@"	$c[0] = $Lift({sm_C1}.$op_Increment($c[0]), Regular);
	$c[0] = $Lift({sm_C1}.$op_Increment($c[0]), Regular);
	$c[0] = $Lift({sm_C1}.$op_Decrement($c[0]), Regular);
	$c[0] = $Lift({sm_C1}.$op_Decrement($c[0]), Regular);
");
		}

		[Test]
		public void LiftedIncrementAndDecrementOperatorsWorkOnArraysWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1?[] c = null;
	// BEGIN
	c[0]++;
	++c[0];
	c[0]--;
	--c[0];
	// END
}",
@"	$c[0] = $Lift({sm_C1}.$op_Increment($c[0]), Regular);
	$c[0] = $Lift({sm_C1}.$op_Increment($c[0]), Regular);
	$c[0] = $Lift({sm_C1}.$op_Decrement($c[0]), Regular);
	$c[0] = $Lift({sm_C1}.$op_Decrement($c[0]), Regular);
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedPreIncrementAndDecrementOperatorsWorkOnArraysWhenAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1?[] c = null;
	C1? c1, c2;
	// BEGIN
	c1 = ++c[0];
	c2 = --c[0];
	// END
}",
@"	$c1 = $c[0] = $Lift({sm_C1}.$op_Increment($c[0]), Regular);
	$c2 = $c[0] = $Lift({sm_C1}.$op_Decrement($c[0]), Regular);
");
		}

		[Test]
		public void LiftedPreIncrementAndDecrementOperatorsWorkOnArraysWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1?[] c = null;
	C1? c1 = null, c2 = null;
	// BEGIN
	c1 = ++c[0];
	c2 = --c[0];
	// END
}",
@"	$c[0] = $Lift({sm_C1}.$op_Increment($c[0]), Regular);
	$c1 = $Clone($c[0], {to_C1});
	$c[0] = $Lift({sm_C1}.$op_Decrement($c[0]), Regular);
	$c2 = $Clone($c[0], {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedPostIncrementAndDecrementOperatorsWorkOnArraysWhenAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1?[] c = null;
	C1? c1, c2;
	// BEGIN
	c1 = c[0]++;
	c2 = c[0]--;
	// END
}",
@"	var $tmp1 = $c[0];
	$c[0] = $Lift({sm_C1}.$op_Increment($tmp1), Regular);
	$c1 = $tmp1;
	var $tmp2 = $c[0];
	$c[0] = $Lift({sm_C1}.$op_Decrement($tmp2), Regular);
	$c2 = $tmp2;
");
		}

		[Test]
		public void LiftedPostIncrementAndDecrementOperatorsWorkOnArraysWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
void M() {
	C1?[] c = null;
	C1? c1, c2;
	// BEGIN
	c1 = c[0]++;
	c2 = c[0]--;
	// END
}",
@"	var $tmp1 = $c[0];
	$c[0] = $Lift({sm_C1}.$op_Increment($Clone($tmp1, {to_C1})), Regular);
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = $c[0];
	$c[0] = $Lift({sm_C1}.$op_Decrement($Clone($tmp2, {to_C1})), Regular);
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedIncrementAndDecrementOperatorsWorkOnPropertiesWhenNotAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? P { get; set; }
void M() {
	// BEGIN
	P++;
	++P;
	P--;
	--P;
	// END
}",
@"	this.set_$P($Lift({sm_C1}.$op_Increment(this.get_$P()), Regular));
	this.set_$P($Lift({sm_C1}.$op_Increment(this.get_$P()), Regular));
	this.set_$P($Lift({sm_C1}.$op_Decrement(this.get_$P()), Regular));
	this.set_$P($Lift({sm_C1}.$op_Decrement(this.get_$P()), Regular));
");
		}

		[Test]
		public void LiftedIncrementAndDecrementOperatorsWorkOnPropertiesWhenNotAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? P { get; set; }
void M() {
	// BEGIN
	P++;
	++P;
	P--;
	--P;
	// END
}",
@"	this.set_$P($Lift({sm_C1}.$op_Increment(this.get_$P()), Regular));
	this.set_$P($Lift({sm_C1}.$op_Increment(this.get_$P()), Regular));
	this.set_$P($Lift({sm_C1}.$op_Decrement(this.get_$P()), Regular));
	this.set_$P($Lift({sm_C1}.$op_Decrement(this.get_$P()), Regular));
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedPreIncrementAndDecrementOperatorsWorkOnPropertiesWhenAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? P { get; set; }
void M() {
	C1? c1, c2;
	// BEGIN
	c1 = ++P;
	c2 = --P;
	// END
}",
@"	var $tmp1 = $Lift({sm_C1}.$op_Increment(this.get_$P()), Regular);
	this.set_$P($tmp1);
	$c1 = $tmp1;
	var $tmp2 = $Lift({sm_C1}.$op_Decrement(this.get_$P()), Regular);
	this.set_$P($tmp2);
	$c2 = $tmp2;
");
		}

		[Test]
		public void LiftedPreIncrementAndDecrementOperatorsWorkOnPropertiesWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? P { get; set; }
void M() {
	C1? c1, c2;
	// BEGIN
	c1 = ++P;
	c2 = --P;
	// END
}",
@"	var $tmp1 = $Lift({sm_C1}.$op_Increment(this.get_$P()), Regular);
	this.set_$P($Clone($tmp1, {to_C1}));
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = $Lift({sm_C1}.$op_Decrement(this.get_$P()), Regular);
	this.set_$P($Clone($tmp2, {to_C1}));
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void LiftedPostIncrementAndDecrementOperatorsWorkOnPropertiesWhenAssigningTheResult() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? P { get; set; }
void M() {
	C1? c1, c2;
	// BEGIN
	c1 = P++;
	c2 = P--;
	// END
}",
@"	var $tmp1 = this.get_$P();
	this.set_$P($Lift({sm_C1}.$op_Increment($tmp1), Regular));
	$c1 = $tmp1;
	var $tmp2 = this.get_$P();
	this.set_$P($Lift({sm_C1}.$op_Decrement($tmp2), Regular));
	$c2 = $tmp2;
");
		}

		[Test]
		public void LiftedPostIncrementAndDecrementOperatorsWorkOnPropertiesWhenAssigningTheResultStruct() {
			AssertCorrect(@"
struct C1 {
	public static C1 operator++(C1 c) { return default(C1); }
	public static C1 operator--(C1 c) { return default(C1); }
}
C1? P { get; set; }
void M() {
	C1? c1, c2;
	// BEGIN
	c1 = P++;
	c2 = P--;
	// END
}",
@"	var $tmp1 = this.get_$P();
	this.set_$P($Clone($Lift({sm_C1}.$op_Increment($Clone($tmp1, {to_C1})), Regular), {to_C1}));
	$c1 = $Clone($tmp1, {to_C1});
	var $tmp2 = this.get_$P();
	this.set_$P($Clone($Lift({sm_C1}.$op_Decrement($Clone($tmp2, {to_C1})), Regular), {to_C1}));
	$c2 = $Clone($tmp2, {to_C1});
", mutableValueTypes: true);
		}

		[Test]
		public void UserDefinedOperatorImplementedAsNativeOperatorIsNotInvoked() {
			AssertCorrect(@"
class C1 {
	public static C1 operator+(C1 c1, C1 c2) {
		return null;
	}
}
void M() {
	C1 c1 = null, c2 = null, c3;
	// BEGIN
	c3 = c1 + c2;
	// END
}",
@"	$c3 = $c1 + $c2;
", metadataImporter: new MockMetadataImporter { GetMethodSemantics = m => m.IsOperator ? MethodScriptSemantics.NativeOperator() : MethodScriptSemantics.NormalMethod(m.Name) });
		}
	}
}


